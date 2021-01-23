    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)  
                {
                    System.Data.Common.DbDataRecord dbdr = (System.Data.Common.DbDataRecord) e.Item.DataItem;
    
                    // Access Data in the Datareader
                    int MD = Convert.ToInt32 (dbdr [2]);
                    int MN = Convert.ToInt32 (dbdr [3]);
                    DateTime DT = Convert.ToDateTime (dbdr [1]);
    
                    if (DT <= System.DateTime.Today || MD <= MN)
                    {
                        e.Item.CssClass = "red";
                    }
                }
            }
