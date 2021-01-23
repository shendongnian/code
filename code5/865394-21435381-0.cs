    public static void UpdateDataBase(List<POSUnitRecord> POSs)
            {
                EPOSEntities db = new EPOSEntities();
                var ent = from epos in db.Records;
                          //where epos.
                          //Columns in 'Records' table are 'Id' & 'Folder'
    
                foreach (POSUnitRecord pos in POSs)
                {
                    Record aRecord = new Record();
                    aRecord.Id = pos.Id;
                    aRecord.Folder = pos.FolderPath
                    aRecord.New="put your value";
                    ent.Add(aRecord);
                }            
        }
