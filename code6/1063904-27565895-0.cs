    [WebMethod(EnableSession = true)]
    public static void InsertData(string LocationID, string ProductID, string Quantity)
    {
        MastersClient objIndent = new MastersClient();
        DataTable dtGrid = (DataTable)HttpContext.Current.Session["VSOrderForm"];
        //Read from session
        DataTable Orderdbl = (DataTable)HttpContext.Current.Session["OrderForm"];
        // DataSet ds = objIndent.CheckForExistingOrder(Int32.Parse(LocationID), ProductID);
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
            if (Orderdbl == null)
            {
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
            
            else
            {
                string FilterCond1 = "ProductID=" + ProductID;
                DataRow[] newrow = Orderdbl.Select(FilterCond1);
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
                
            }
        }
    }
