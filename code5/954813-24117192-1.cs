    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList dropdown = (DropDownList)e.Row.FindControl("DropDownList3");
            ClassDal obj = new ClassDal();
            List<phone> list = obj.GetAll();
            dropdown.DataSource = list.ToList();
            dropdown.DataTextField = "phone";
            dropdown.DataValueField = "id";
             dropdown.DataBind();
    
        } 
