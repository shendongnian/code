    public static void InsertData(string LocationID, string ProductID, string Quantity)
    {
        MastersClient objIndent = new MastersClient();
        DataTable dtGrid = (DataTable)HttpContext.Current.Session["VSOrderForm"];
        DataTable Orderdbl = (DataTable)HttpContext.Current.Session["OrderForm"];
        // DataSet ds = objIndent.CheckForExistingOrder(Int32.Parse(LocationID), ProductID);
        //Check in first table
        var DataCheck = dtGrid.Select("ProductID = '" + ProductID + "'");
        if (DataCheck.Length != 0)
        {
            // do something...
        }
        //if (ds != null && ds.Tables.Count > 0)
        //{
        //}
        else
        {
            //Not found in first now check in second talbe
            if (Orderdbl != null)
            {
                string FilterCond1 = "ProductID=" + ProductID;
                DataRow[] newrow = Orderdbl.Select(FilterCond1);
                //If Length > 0 it means found in second table,
                if (newrow.Length > 0)
                {
                    for (int i = 0; i < newrow.Length; i++)
                    {
                        if (newrow[i]["ProductID"].ToString() == ProductID)
                        {
                            // YOUR CODE HERE 
                        }
                    }
                }
                else
                {
                    //Not found in second talbe now add new row
                    Orderdbl.Columns.Add("LocationID", typeof(string));
                    Orderdbl.Columns.Add("ProductID", typeof(string));
                    Orderdbl.Columns.Add("Quantity", typeof(string));
                    DataRow row = Orderdbl.NewRow();
                    //if (string.IsNullOrEmpty((string)Orderdbl.Rows[i][j].value))
                    row["LocationID"] = LocationID;
                    row["ProductID"] = ProductID;
                    Orderdbl.Rows.Add(row);
                    HttpContext.Current.Session["OrderForm"] = Orderdbl;
                }
            }
            else
            {
                //This will run first time when session has no value.
                Orderdbl = new DataTable();
                Orderdbl.Columns.Add("LocationID", typeof(string));
                Orderdbl.Columns.Add("ProductID", typeof(string));
                Orderdbl.Columns.Add("Quantity", typeof(string));
                DataRow row = Orderdbl.NewRow();
                //if (string.IsNullOrEmpty((string)Orderdbl.Rows[i][j].value))
                row["LocationID"] = LocationID;
                row["ProductID"] = ProductID;
                Orderdbl.Rows.Add(row);
                HttpContext.Current.Session["OrderForm"] = Orderdbl;
            }
     
        }
    }
