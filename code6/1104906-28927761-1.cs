    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      GridView1.PageIndex = e.NewPageIndex;
      BusinessLogic.clsGeneral objGen = new BusinessLogic.clsGeneral();
      string strquery = "select * from Products where status = 1";
      DataTable dt = objGen.ExecuteQueryReturnDatatable(strquery);
      GridView1.DataSource = dt;
      GridView1.DataBind();
    }
