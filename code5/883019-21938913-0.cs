    foreach (Line invoiceLine in x.Line)
                    {
                        itm = new LineItem();
                        
                        if (invoiceLine.Amount != 0)
                        {
                            itm.Description = invoiceLine.Description;
                            itm.Description = String.IsNullOrEmpty(itm.Description) ? "n/a" : itm.Description;
 
    if (invoiceLine.DetailType == LineDetailTypeEnum.AccountBasedExpenseLineDetail)
                            {
                                AccountBasedExpenseLineDetail itemLineDetail =
                                    invoiceLine.AnyIntuitObject as AccountBasedExpenseLineDetail;
                                itm.Quantity = 1;
                                itm.UnitAmount = invoiceLine.Amount;
                                itm.AccountCode = itemLineDetail.AccountRef.Value;
                            }
