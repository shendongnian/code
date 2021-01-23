    using (Transaction acTrans = acDb.TransactionManager.StartTransaction())
    {
        var acBlkTbl = (BlockTable)acTrans.GetObject(acDb.BlockTableId, OpenMode.ForRead);
        var acBlkTblRec = (BlockTableRecord)acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
        // Create the rectangle
        var acPoint = new Point2d(0, 0);
        var acPoly = new Polyline(4);
        acPoly.Normal = Vector3d.ZAxis;
        acPoly.AddVertexAt(0, acPoint, 0, -1, -1);
        acPoly.AddVertexAt(1, new Point2d(acPoint.X + 20, acPoint.Y), 0, -1, -1);
        acPoly.AddVertexAt(2, new Point2d(acPoint.X + 20, acPoint.Y + 20), 0.0, -1.0, -1.0);
        acPoly.AddVertexAt(3, new Point2d(acPoint.X, acPoint.Y + 20), 0.0, -1.0, -1.0);
        acPoly.Closed = true;
        // Add the rectangle to the block table record
        acBlkTblRec.AppendEntity(acPoly);
        acTrans.AddNewlyCreatedDBObject(acPoly, true);
        // Create the rectangle hole
        var acHole = new Polyline(4);
        acHole.Normal = Vector3d.ZAxis;
        acPoint = new Point2d(5,5);
        acHole.AddVertexAt(0, acPoint, 0.0, -1.0, -1.0);
        acHole.AddVertexAt(1, new Point2d(acPoint.X + 5, acPoint.Y), 0.0, -1.0, -1.0);
        acHole.AddVertexAt(2, new Point2d(acPoint.X + 5, acPoint.Y + 5), 0.0, -1.0, -1.0);
        acHole.AddVertexAt(3, new Point2d(acPoint.X, acPoint.Y + 5), 0.0, -1.0, -1.0);
        acHole.Closed = true;
        // Add the hole rectangle to the block table record
        acBlkTblRec.AppendEntity(acHole);
        acTrans.AddNewlyCreatedDBObject(acHole, true);
        // Create the hatch
        var acHatch = new Hatch();
        acBlkTblRec.AppendEntity(acHatch);
        acTrans.AddNewlyCreatedDBObject(acHatch, true);
        acHatch.SetDatabaseDefaults();
        acHatch.SetHatchPattern(HatchPatternType.PreDefined, "ANSI31");
        acHatch.PatternScale = 10;
        acHatch.Associative = true;
        // Add the outer boundary
        acHatch.AppendLoop(HatchLoopTypes.External, new ObjectIdCollection { acPoly.ObjectId });
                    
        // Add the inner boundary
        acHatch.AppendLoop(HatchLoopTypes.Default, new ObjectIdCollection { acHole.ObjectId });
                    
        // Validate the hatch
        acHatch.EvaluateHatch(true);
        acTrans.Commit();
    }
