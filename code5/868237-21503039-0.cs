    var contracts = dbconnect.tblContracts.Where(i => i.tender == _tenderId)
                     .ToList()   //Query executes here, now you have IEnumerable<T>
                     .Select(i => new PresentationContract {
                                      Tax = ...
                                  }).ToList();  //this ToList is only necessary if you want to prevent multiple iteration
