    var result = e.CMR_INVHDR
                  .Where(r => r.ProcessedLike != "STMNT ONLY")
                  .GroupBy(r => new { r.SecurityCode, r.DataProcessingFlag })
                  .Select(r => new { Value = r.Key, Count = r.Count() })
                  .ToList();
