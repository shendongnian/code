    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
            {
                DropDownList box2 = (DropDownList)GridView1.Rows[i].Cells[1].FindControl("DropDownList1");
                box2.DataSource = SIMBL.ShowSalesOrderArticleNumberInfo();
                box2.DataTextField = "Port_Number";
                box2.DataValueField = "Description";
                box2.DataBind();
                box2.Items.Insert(0, " ");
    
        DropDownList box12 = (DropDownList)GridView1.Rows[i].Cells[4].FindControl("DropDownList3");
            box12.DataSource = SIMBL.ShowUnitItemInfo();
            box12.DataTextField = "Name";
            box12.DataValueField = "Symbol";
            box12.DataBind();
            box12.Items.Insert(0, " ");
    
            DropDownList box13 = (DropDownList)GridView1.Rows[i].Cells[4].FindControl("DropDownList4");
            box13.DataSource = SIMBL.ShowUnitItemInfo();
            box13.DataTextField = "Name";
            box13.DataValueField = "Symbol";
            box13.DataBind();
            box13.Items.Insert(0, " ");
    
            DropDownList box14 = (DropDownList)GridView1.Rows[i].Cells[4].FindControl("DropDownList5");
            box14.DataSource = SIMBL.ShowUnitItemInfo();
            box14.DataTextField = "Name";
            box14.DataValueField = "Symbol";
            box14.DataBind();
            box14.Items.Insert(0, " ");
    		
    }
