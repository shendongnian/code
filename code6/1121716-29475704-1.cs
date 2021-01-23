                var finalResult = from x in searchResults.Hits
                       select new AlertListRow
                              {
                                  AlertCode = x.Source.AlertCode,
                                  AlertDate = x.Source.AlertDate,
                                  AlertID = x.Id,
                                  AlertSummary = x.Source.Subject,
                                  AlertMessage = x.Source.Body
                              };
