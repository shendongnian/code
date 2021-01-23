    var result = e.CMR_INVHDR
                  .Where(r => r.ProcessedLike != "STMNT ONLY")
                  .GroupBy(r => new { r.SecurityCode, r.DataProcessingFlag })
                  .Select(r => new 
                  { 
                      Value = r.Key, 
                      IssuerCodesCount = r.GroupBy(g => g.IssuerCode).Count() 
                  })
                  .ToList();
