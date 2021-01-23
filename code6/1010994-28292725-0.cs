    DataTable dtMerge = new DataTable();
    
    Parallel.ForEach(strFilePath,
         () => new DataTable(),
         (filePath, loopState, local) =>
         {
             clsNewClass objCls=new clsNewClass();
             // Is it possible like the below?
             var dt = objCls.ReadCSV(filePath);
             local.Merge(dt, true, MissingSchemaAction.Add);
             return local;
         },
         (local) =>
         {
             lock(dtMerge)
             {
                 dtMerge.Merge(local, true, MissingSchemaAction.Add);
             }
         });
