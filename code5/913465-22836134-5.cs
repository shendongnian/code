     BranchData b = new BranchData();
     using(var sr = new StreamReader(AsyncFileUploadBranch.FileContent))
     {
         using (var csvReader = new CsvReader(sr))
         {
             var result = csvReader.GetRecords<BranchData>().ToArray();
             foreach (var rec in result)
             {
                //get details
                b.Id = rec.Id;
                b.Branch = rec.Branch;
                b.Active = rec.Active;
                b.SaveBranches();
             }
         }
     }
             
