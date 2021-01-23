    using(SqlConnection con = new SqlConnection(cs))
    {
        using(SqlCommand cmd = new SqlCommand("select 'Select Gender' genderName, 0 genderID UNION ALL select genderName, genderId from Gender", con))
        { 
            con.Open();
            DropDownList1.DataSource =  cmd.ExecuteReader();
            DropDownList1.DataTextField = "genderName";
            DropDownList1.DataValueField = "genderID";
            DropDownList1.DataBind();
        }
    }
