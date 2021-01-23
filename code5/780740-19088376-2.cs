    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "datacommand")
        {
            DataTable dt = new DataTable();
            if (Session["product_id"] != null)
            {
                dt = (DataTable)Session["product_id"];
            }
            DataRow dr;
            //dt.Rows[0]["qty"] = data;
            if (dt.Rows.Count<=0)
            {
                dt.Columns.Add("product_id", typeof(Int32));
                dt.Columns.Add("qty", typeof(int));
                dt.Columns.Add("price", typeof(double));
                dt.Columns.Add("total", typeof(double));
                dr = dt.NewRow();
                dr["product_id"] = e.CommandArgument;
                dr["qty"] = 1;
                dr["price"] = Convert.ToDouble(GridView1.Rows[0].Cells[3].Text);
                dr["total"] = Convert.ToInt32(dr["qty"]) * Convert.ToDouble(dr["price"]);
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                Session["product_id"] = dt;
                Response.Write("<script type='javacript'> One time</script>");
            }
            else
            {
               //dt = Session["product_id"];
                string aa="new";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["product_id"].ToString() == e.CommandArgument)
                    {
                         aa="dup";
                        
                    }
               }
                if(aa=="dup")
                {
                     for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[j]["product_id"].ToString() == e.CommandArgument)
                        {
                            // aa="dup";
                            dt.Rows[j]["qty"]=Convert.ToString( Convert.ToInt32( dt.Rows[j]["qty"])+1);
                            dt.AcceptChanges();
                        }
                    }
                    Session["product_id"]=dt;
                }
                else
                {
                dt.Columns.Add("product_id", typeof(Int32));
                dt.Columns.Add("qty", typeof(int));
                dt.Columns.Add("price", typeof(double));
                dt.Columns.Add("total", typeof(double));
                DataRow dr1=dt.NewRow() ;
                dr1["product_id"] = e.CommandArgument;
                dr1["qty"] = 1;
                dr1["price"] = Convert.ToDouble(GridView1.Rows[0].Cells[3].Text);
                dr1["total"] = Convert.ToInt32(dr["qty"]) * Convert.ToDouble(dr["price"]);
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                Session["product_id"] = dt;
            }
       }
        //GridViewRow row=    e.CommandArgument
        ////DataColumn prodid = new DataColumn("product_id", typeof(System.Int32));
        ////dt.Columns.Add(prodid);
        ////DataColumn qty = new DataColumn("qty", typeof(System.Int32));
        ////dt.Columns.Add(qty);
        //int index = Convert.ToInt32(e.CommandArgument);
        //GridViewRow row = GridView1.Rows[index];
        //AddShopCart(row.Cells[1].Text.ToString());
    }
    }
