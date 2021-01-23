    // Define a method to return an IList of that data container class defined above
    public IList<SalesInfo> GetSalesInfo()
    {
        // please, as of .NET 2.0 - use the List<T> and stop using ArrayList!
        IList<SalesInfo> list = new List<SalesInfo>();
        try
        {
            // put your context usage into using()..... blocks to ensure proper disposal
            using (var context = new SabzNegar01Entities1())
            {
                 // fetch the data, turn it into SalesInfo records
                 list = (from p in context.tbl_ReturnSalesFactor_D
                         where p.DocNo == inDocNo
                         select new SalesInfo
                                {
                                    Row = p.Row,
                                    StockCode = p.StockCode,
                                    Description = p.tbl_Stock.PDescription,
                                    Fee = p.Fee,
                                    MainNum = p.MainNum,
                                    Add = p.MainNum*p.Fee,
                                    PureAdd = ((p.MainNum*p.Fee) - (p.MainNum*p.Discount)) + ((p.Tax + p.Charges)*p.MainNum),
                                    Discount = p.Discount*p.MainNum,
                                    TaxChange = (p.Tax + p.Charges)*p.MainNum
                                }).ToList();
            }
            // if you get back no data -> add a dummy entry
            if (list.Count <= 0)
            {
                 list.Add(new SalesInfo { Description = "(no data found)" });
            }
        }
        catch (Exception ex)
        {
            PMessageBox.Show(ex.Message, "Error in Reading  ReturnSalesFactor_Details Data");
        }
        // return the resulting list
        return list;
    }
