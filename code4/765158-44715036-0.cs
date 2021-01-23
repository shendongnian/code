        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT GatePassNo,PurposeOfVisit FROM VisitorList"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                DropDownList ddlpurposeofvisit = (DropDownList)e.Row.FindControl("ddlpurposeofvisit");
                ddlpurposeofvisit.DataSource = cmd.ExecuteReader();
                ddlpurposeofvisit.DataTextField = "PurposeOfVisit";
                ddlpurposeofvisit.DataValueField = "GatePassNo";
                ddlpurposeofvisit.DataBind();
                con.Close();
            }
        }
     
    }
