    Federations = u.FederatedUsername != null
                      ? new List<Federation>() {
                            new Federation {
                                FederatedUsername = u.FederatedUsername
                            }
                         }
                      : null,
