    protected void gvOutDCItemDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                //{
                    DropDownList ddList = (DropDownList)e.Row.FindControl("ddrProcess");
                    //bind dropdownlist
                    SqlCommand cmd = new SqlCommand("sp_getProcess", con1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    //DataTable dt = con1.GetData("Select category_name from category");
                    ddList.DataSource = dt;
                    ddList.DataTextField = "PName";
                    ddList.DataValueField = "Process_Id";
                    ddList.DataBind();
                    ddList.Items.Insert(0,new ListItem("--SELECT--","0"));
                    TextBox txtDispatchQuantity = (TextBox)e.Row.FindControl("txtDispatchQuantity");
                    
                    var dataRow = (DataRowView)e.Row.DataItem;
                    var Dispatch_Qty = "Dispatch_Qty";
                    var check = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(Dispatch_Qty, StringComparison.InvariantCultureIgnoreCase));
                    if (check)
                    {
                        // Property available
                        txtDispatchQuantity.Text =ds1.Tables[0].Rows[0][7].ToString();
                    }
                              
                    }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
              //  Label lblTotalPrice = (Label)e.Row.FindControl("Total_Amount");
                //lblTotalPrice.Text = total.ToString();
               // txttotalAmount.Text = Total.ToString();
            }
            
        }
