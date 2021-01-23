    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
            {
                DropDownList box2 = (DropDownList)GridView1.Rows[0].Cells[1].FindControl("DropDownList1");
                box2.DataSource = SIMBL.ShowSalesOrderArticleNumberInfo();
                box2.DataTextField = "Port_Number";
                box2.DataValueField = "Description";
                box2.DataBind();
                box2.Items.Insert(0, " ");
    
    
            }
		
