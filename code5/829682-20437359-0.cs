      // this is the removed line
       Subgroups = from privateTokens in myGroup
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
