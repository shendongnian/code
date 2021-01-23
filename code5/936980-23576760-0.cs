    TextBox txtDispatchQuantity = (TextBox)e.Row.FindControl("txtDispatchQuantity");
                    
                    var dataRow = (DataRowView)e.Row.DataItem;
                    var Dispatch_Qty = "Dispatch_Qty";
                    var check = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(Dispatch_Qty, StringComparison.InvariantCultureIgnoreCase));
                    if (check)
                    {
                        // Property available
                        txtDispatchQuantity.Text =ds1.Tables[0].Rows[0][7].ToString();
                    }
                              
