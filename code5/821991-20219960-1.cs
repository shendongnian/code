    var customerInfos = customerTitlesAndIDs.Select((c)=>{
                            var ci = new SCustomerInfo(CreateCustomerTable(), c.ID, customer.CustomerTitle);
                            ci.PaymentTable = ci.PaymentTable.AsEnumerable().Union(
                                              cutomerIdPayment.Where(j=>j.ID == c.ID)
                                                              .Select(j=>{
                                                                  var dtRow = ci.PaymentTable.NewRow();
                                                                  dtRow.ItemArray = new object[] {
                                                                      customerPayment.Range,
                                                                      customerPayment.Values 
                                                                  };
                                                                  return dtRow;
                                              })).CopyToDataTable();
                            return ci;
                        }).ToList();
