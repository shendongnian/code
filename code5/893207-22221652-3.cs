    protected void btnImport_Click(object sender, EventArgs e)
    {
        InventoryGrid.DataBind();
        ErrorsGrid.DataBind();        
        //set visibility of btnGenerate in Page_Load also;
        btnGenerate.Visible = ErrorsGrid.Rows.Count == 0;
    }
