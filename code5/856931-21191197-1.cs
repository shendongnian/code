    public IEnumerable<KeyValuePair<string, string>> Import(string filePath
                                                            , string formatFilePath)
    {
       var errors = new List<KeyValuePair<string, string>>();
       ImportFromFileToStagingTable(filepath, formatfilepath);
    
       IQueryable<DataImport> staged = Uow.DataImportRepository.All;
    
       var invalidAccNo = staged.Where(p => String.IsNullOrEmpty(p.VisitKey))
                                .Select(p => new
                                {
                                   Key = "Missing VisitKey",
                                   Value = p.AccountNumber
                                });
    
       var invalidCodeKey = staged //etc
    
       var query = invalidAccNo.Concat(invalidCodeKey)
       
       errors.AddRange(query.AsEnumerable()
                            .Select(x => new KeyValuePair<string, string>(x.Key
                                                                        , x.Value)));
    
       if (errors.Count == 0)
       {
          TransferToMainTable();
          DeleteImport();
          Uow.Save();
       }
    
       return errors;
    }
