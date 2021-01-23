      System.Globalization.DateTimeFormatInfo DFI=new System.Globalization.DateTimeFormatInfo();
                var InvoiceDetailMonthwise = (from t in clsGlobalObjectRefrances.SchoolSoulController.Stt.ssspAccInvoiceBook(clsSchoolSoulObjects.OAcdSchoolInfo.SchoolId,clsSchoolSoulObjects.OAcdSchoolInfo.CurrentActiveSessionId )
                                              group t by new { t.VDate.Value.Month} 
                                                  into grp
                                                  select new lcclsInvoiceBook
                                                  {
                                                      Month=DFI.GetMonthName( grp.Key.Month).ToString(),
                                                      Debit = grp.Sum(t => t.DebitAmount) > 0 ? 0 : -(grp.Sum(t => t.DebitAmount)),
                                                      Credit = grp.Sum(t => t.CreditAmount ) > 0 ? (grp.Sum(t => t.CreditAmount )) : 0,
                                                                   
                                                  }).ToList();
    
    
    
                dgvInvoiceBook.DataSource = InvoiceDetailMonthwise;
