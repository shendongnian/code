    using(SqlConnection con = new SqlConnection(cs))
    {
        using(SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Gender", con))
        { 
            con.Open();
            DropDownList1.DataSource =  cmd.ExecuteReader();
            DropDownList1.DataTextField = "GenderName";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataBind();
    
            ListItem li = new ListItem("Select Gender", "-1");
            DropDownList1.Items.Insert(0, li);
        }
    } 
