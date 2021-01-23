    QueryService<Invoice> bill1QueryService = new QueryService<Invoice>(context);
    Invoice bill11 = bill1QueryService.ExecuteIdsQuery("select * from Invoice").FirstOrDefault<Invoice>();
     SalesItemLineDetail a1 = (SalesItemLineDetail)bill11.Line[0].AnyIntuitObject;
                            
                            if(a1.TaxCodeRef.Value=="TAX")
                            {
                                string taxCodeid = a1.ItemRef.Value;
                                object unitprice = a1.AnyIntuitObject;
                                decimal quantity = a1.Qty;
                            }
