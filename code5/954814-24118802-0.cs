    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList dropdown = (DropDownList)e.Row.FindControl("DropDownList3");
            ClassDal obj = new ClassDal();
            List<phone> list = obj.GetAll();
            dropdown.DataTextField = "phone";
            dropdown.DataValueField = "id";
            dropdown.DataSource = list.ToList();  // <- why are you doing list.ToList()?
            dropdown.DataBind();
        }
    } 
