    void SaveBranchDetails(HttpPostedFile file)
        {
            try
            {
                BranchData b = new BranchData();
                using (var reader = new StreamReader(file.InputStream))
                using (var csvReader = new CsvReader(reader))
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
            catch (Exception)
            {
                throw;
            }
        }
