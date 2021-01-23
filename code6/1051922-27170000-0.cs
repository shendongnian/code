        DataTable common = new Common(); // Id, UserType, UserTypeId
        var sections = common.Where(c => c.UserType.ToString() == "B").First()
                             .ToString().Split(',');
        DataTable dtDownlist = new DataTable();
        dtDownlist.Columns.Add("UserTypeId");
        dtDownlist.Columns.Add("UserType");
        DataRow dr;
        foreach (string id in sections)
        {
            for (int i = 0; i < dtUserType.Rows.Count; i++)
            {
                if(Convert.ToInt16(id) == Convert.ToInt16(common.Rows[i]["Id"]))
                {
                    dr = dtDownlist.NewRow();
                    dr["USerType"] = dtUserType.Rows[i]["UserType"].ToString();
                    dr["UserTypeId"] = dtUserType.Rows[i]["UserTypeId"].ToString();
                    dtDownlist.Rows.Add(dr);
                }
            }
        }
        cmbUser.DataSource = dtDownlist; 
        cmbUser.DataTextField = "UserType";
        cmbUser.DataValueField = "UserTypeId";
        cmbUser.DataBind();
