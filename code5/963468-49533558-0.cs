    [CommandMethod("ModifyAndSaveas", CommandFlags.Redraw | CommandFlags.Session)]
        public void ModifyAndSaveAs()
        {
            Document acDoc = Application.DocumentManager.Open(sourcefile);
            Database acDB = acDoc.Database;
            Transaction AcTran = acDoc.Database.TransactionManager.StartTransaction();
            using (DocumentLock acLckDoc = acDoc.LockDocument())
            {
                using (AcTran)
                {
                    BlockTable acBLT = (BlockTable)AcTran.GetObject(acDB.BlockTableId, OpenMode.ForRead);
                    BlockTableRecord acBLTR = (BlockTableRecord)AcTran.GetObject(acBLT[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                    var editor = acDoc.Editor;                  
                    var SelectionSet = editor.SelectAll().Value;
                    foreach (ObjectId id in SelectionSet.GetObjectIds())
                    {
                        Entity ent = AcTran.GetObject(id, OpenMode.ForRead) as Entity;
                        //modify entities 
                    }
                    AcTran.Commit();
                }
            }
            acDB.SaveAs(newfile, DwgVersion.AC1021);
        }
