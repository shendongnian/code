    var query = from f in this.dbContext.Tokens
            group f by new { f.PI, f.TI, f.UIDP, f.AttributesJSON, f.IssuerParameters, f.IsDeviceProtected , f.FriendlyName}
                        into myGroup
                        where myGroup.Count() > 0
                        select new
                        {
                            myGroup.Key.UIDP,
                            myGroup.Key.TI,
                            myGroup.Key.PI,
                            myGroup.Key.AttributesJSON,
                            myGroup.Key.IssuerParameters,
                            myGroup.Key.FriendlyName,
                            Count = myGroup.Count(),
                            Subgroups = myGroup
                        };
    var groupedResult = query.ToList();
    var resultWithSubGroups = from gr in groupedResult
                              select new
                              {
                                  gr.UIDP,
                                  gr.TI,
                                  gr.PI,
                                  gr.AttributesJSON,
                                  gr.IssuerParameters,
                                  gr.FriendlyName,
                                  gr.Count,
                                  Subgroups = from privateTokens in gr
                                              select new 
                                              {
                                                  // AttributesJSON = privateTokens.AttributesJSON,
                                                  // FriendlyName = privateTokens.FriendlyName,
                                                  Id = privateTokens.Id,
                                                  //  IsDeviceProtected = privateTokens.IsDeviceProtected,
                                                  // IssuerParameters = privateTokens.IssuerParameters,
                                                  // PI = privateTokens.PI,
                                                  // PrivateKey = privateTokens.PrivateKey,
                                                  // TI = privateTokens.TI,
                                                  TokenData = privateTokens.TokenData,
                                                  UIDP = privateTokens.UIDP,
                                              }
                               };
