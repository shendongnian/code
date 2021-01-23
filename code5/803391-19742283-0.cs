    cQuery _aRec = new cQuery();
        _aRec.Sqlstring = "SELECT * FROM Admins";
        DataSet aDS = _aRec.SelectStatement();
        DataTable aDT = aDS.Tables[0];
        foreach (DataRow aDR in aDT.Rows){
            if (txtAdminUsername.Text == aDR[0].ToString()){
                if (txtAdminPassword.Text == aDR[1].ToString()){
                    Session["adminId"] = aDR[0];
                    Response.Redirect("Admin.aspx");
                    return;
                }
            }
        }
