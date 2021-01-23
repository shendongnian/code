    var customerInfos = customerTitlesAndIDs.Select((c)=>{
                            var ci = new SCustomerInfo(CreateCustomerTable(), cID, customer.CustomerTitle);
                            ci.PaymentTable = ci.PaymentTable.AsEnumerable().Union(
                                              cutomerIdPayment.Where(j=>j.ID == i.cID)
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
