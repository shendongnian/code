    protected void RadGrid1_PreRender(object sender, EventArgs e)
       {
           //if (!Page.IsPostBack)
           //{
               RadGrid1.MasterTableView.FilterExpression = "([Country] LIKE \'%UK%\') ";
               GridColumn column = RadGrid1.MasterTableView.GetColumnSafe("Country");
               column.CurrentFilterFunction = GridKnownFunction.StartsWith;
               column.CurrentFilterValue = "UK";
               RadGrid1.MasterTableView.Rebind();
           //}
       }
