    var users = UserInfoProvider.GetUsers();
                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[2] { new DataColumn("FullName"), new DataColumn("UserName") });
    
                foreach (UserInfo aUser in users.TypedResult)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["FullName"] = aUser.FullName;
                    newRow["UserName"] = aUser.UserName;
                    dt.Rows.Add(newRow);
                }
    
                GridView1.DataSource = dt;
                GridView1.DataBind();
