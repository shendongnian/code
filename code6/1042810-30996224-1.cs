            /// <summary>
            /// the source drawig should be drawn as number of
            /// separate entites with or without attributes.
            /// Throws NotImplementedException if invoked with .dxf file
            /// </summary>
            /// <param name="sourceDrawing"></param>
            /// <param name="insertionPoint"></param>
            /// <returns>ObjectID of the Block Def that was imported.</returns>
            public void ImportDwgAsBlock(string sourceDrawing, Point3d insertionPoint)
            {
                Matrix3d ucs = _ed.CurrentUserCoordinateSystem;
    
                string blockname = sourceDrawing.Remove(0, sourceDrawing.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                blockname = blockname.Substring(0, blockname.Length - 4); // remove the extension
    
                try
                {
                    using (_doc.LockDocument())
                    {
                        using (var inMemoryDb = new Database(false, true))
                        {
                            #region Load the drawing into temporary inmemory database
                            if (sourceDrawing.LastIndexOf(".dwg", StringComparison.Ordinal) > 0)
                            {
                                inMemoryDb.ReadDwgFile(sourceDrawing, System.IO.FileShare.Read, true, "");
                            }
                            else if (sourceDrawing.LastIndexOf(".dxf", StringComparison.Ordinal) > 0)
                            {
                                _logger.Error(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name + " : Tried to invoke the method with .dxf file.");
                                throw new NotImplementedException("Importing .dxf is not supported in this version.");
                                //inMemoryDb.DxfIn("@" + sourceDrawing, System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\log\\import_block_dxf_log.txt");
                            }
                            else
                            {
                                throw new ArgumentException("This is not a valid drawing.");
                            }
                            #endregion
                                                         
                            using (var transaction =  _db.TransactionManager.StartTransaction())
                            {
                                BlockTable destDbBlockTable = (BlockTable)transaction.GetObject(_db.BlockTableId, OpenMode.ForRead);
                                BlockTableRecord destDbCurrentSpace = (BlockTableRecord)_db.CurrentSpaceId.GetObject(OpenMode.ForWrite);
    
                                // If the destination DWG already contains this block definition
                                // we will create a block reference and not a copy of the same definition
                                ObjectId sourceBlockId;
                                if (destDbBlockTable.Has(blockname))
                                {
    
                                    //BlockTableRecord destDbBlockDefinition = (BlockTableRecord)transaction.GetObject(destDbBlockTable[blockname], OpenMode.ForRead);
                                    //sourceBlockId = destDbBlockDefinition.ObjectId;
    
                                    sourceBlockId = transaction.GetObject(destDbBlockTable[blockname], OpenMode.ForRead).ObjectId;
    
                                    // Create a block reference to the existing block definition
                                    using (var blockReference = new BlockReference(insertionPoint, sourceBlockId))
                                    {
                                        _ed.CurrentUserCoordinateSystem = Matrix3d.Identity;
                                        blockReference.TransformBy(ucs);
                                        _ed.CurrentUserCoordinateSystem = ucs;
                                        var converter = new MeasurementUnitsConverter();
                                        var scaleFactor = converter.GetScaleRatio(inMemoryDb.Insunits, _db.Insunits);
                                        blockReference.ScaleFactors = new Scale3d(scaleFactor);
                                        destDbCurrentSpace.AppendEntity(blockReference);
                                        transaction.AddNewlyCreatedDBObject(blockReference, true);
                                        _ed.Regen();
                                        transaction.Commit();
                                        // At this point the Bref has become a DBObject and (can be disposed) and will be disposed by the transaction
                                    }
                                    return;
                                }
    
                                //else // There is not such block definition, so we are inserting/creating new one
    
                                sourceBlockId = _db.Insert(blockname, inMemoryDb, true);
                                BlockTableRecord sourceBlock = (BlockTableRecord)sourceBlockId.GetObject(OpenMode.ForRead);
                                sourceBlock.UpgradeOpen();
                                sourceBlock.Name = blockname;
                                destDbCurrentSpace.DowngradeOpen();
                                var sourceBlockMeasurementUnits = inMemoryDb.Insunits;
                                try
                                {
                                    CreateBlockReference(sourceBlock.Name, sourceBlockMeasurementUnits,
                                                         insertionPoint,
                                                         destDbCurrentSpace,
                                                         destDbBlockTable);
                                }
                                catch (ArgumentException argumentException)
                                {
                                    _logger.Error("Error. Check inner exception.", argumentException);
                                }
    
                                _ed.Regen();
                                transaction.Commit();
                            }
                        }
                    }
                }
                catch (Autodesk.AutoCAD.Runtime.Exception exception)
                {
                    _logger.Error("Error in ImportDrawingAsBlock().", exception);
                }
            }
    
           
