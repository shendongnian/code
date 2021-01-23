     BranchData b = new BranchData();
     using(var sr = new StreamReader(AsyncFileUploadBranch.FileContent))
     {
         var result = CSV.ReadingCSVFile<BranchData>(sr);
         foreach (var rec in result)
         {
            //get details
            b.Id = rec.Id;
            b.Branch = rec.Branch;
            b.Active = rec.Active;
            b.SaveBranches();
         }
     }
             
