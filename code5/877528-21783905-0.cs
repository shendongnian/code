    [CommandMethod("BlockAttributeSort")]
    public void BlockAttributeSort()
    {
        var acDb = HostApplicationServices.WorkingDatabase;
        var acEd = AcApplication.DocumentManager.MdiActiveDocument.Editor;
            
        try
        {
            using (var acTrans = acDb.TransactionManager.StartTransaction())
            {
                var acBlockTable = (BlockTable)acTrans.GetObject(acDb.BlockTableId, OpenMode.ForRead);
                foreach (ObjectId objId in acBlockTable)
                {
                    var blockDef = objId.GetObject(OpenMode.ForRead) as BlockTableRecord;
                    if (!blockDef.HasAttributeDefinitions)
                        continue;
                    blockDef.UpgradeOpen();
                    var attCollection = new List<AttributeDefinition>();
                    foreach (var attId in blockDef)
                    {
                        var attDef = acTrans.GetObject(attId, OpenMode.ForWrite) as AttributeDefinition;
                        if (attDef == null)
                            continue;
                        attCollection.Add((AttributeDefinition)attDef.Clone());
                        attDef.Erase();
                    }
                    foreach (var att in attCollection.OrderBy(a => a.Tag))
                    {
                        blockDef.AppendEntity(att);
                        acTrans.AddNewlyCreatedDBObject(att, true);
                    }
                }
                acTrans.Commit();
            }
        }
        catch (System.Exception ex)
        {
            Debug.WriteLine(ex.ToString());
            acEd.WriteMessage(ex.ToString());
        }
    }
