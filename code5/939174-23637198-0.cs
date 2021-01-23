    foreach ( var p in API.Query.GetAccoutsCustomers)
    {
                var tmpatagridView = new GridView();
                
    			Dataset ds = API.Query.GetCustomerOrders(p.CusId);
    			dt = ds.Tables[0];
    			for (int i = 0; i < dt.Columns.Count; i++)
                {
                		HyperLinkField hplnk = new HyperLinkField();
    					hplnk.DataTextField = dt.Columns[i].ColumnName.ToString();
    					hplnk.HeaderText = dt.Columns[i].ColumnName.ToString();
    					tmpatagridView.Columns.Add(hplnk);
                }
    
                tmpatagridView.DataSource = ds.Tables[0];
                tmpatagridView.DataBind();
    			Panel1.Controls.Add(tmpatagridView);
    }
