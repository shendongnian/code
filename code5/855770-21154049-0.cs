    var data = (from t in _Entity.TblInvoices
                  join t0 in _Entity.TblClients on new { ReceiverCode = t.ReceiverCode } equals new { ReceiverCode = t0.ClientCode }
                  select new
                  {
                      t.RakeNumber,
                      t.ReceiverCode,
                      t.ConsigneeCode,
                      t.InvoiceNumber,
                      t.InvoiceDate,
                      t.RecordStatus,
                      t0.ClientCode,
                      t0.ClientDescription,
                      t0.ClientAddress1,
                      t0.ClientAddress2,
                      t0.ClientAddress3,
                      t0.ClientCity,
                      t0.ClientState,
                      t0.ClientCountry,
                      t0.ClientZipCode,
                  }).Union( // 2nd linq query with same result set as first here);
