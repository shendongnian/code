    protected void gvCktMap_PreRender(object sender, EventArgs e) 
    { 
        gvCktMap.MasterTableView.GetColumn("sid").Visible = false;  
        gvCktMap.MasterTableView.GetColumn("customername").Visible = false; 
        gvCktMap.MasterTableView.GetColumn("marketname").Visible = false; 
        gvCktMap.Rebind(); 
    } 
