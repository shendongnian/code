                DataTable dt = new DataTable();
                dt.Columns.Add("Name", DbType.String);
                dt.Columns.Add("Gender", DbType.String);
                dt.Columns.Add("Email", DbType.String);
                dt.Columns.Add("DateofBirth", DbType.String);
                dt.Columns.Add("Nationality", DbType.String);
                dt.Columns.Add("Mobile", DbType.String);
                dt.Columns.Add("Course", DbType.String);
                dt.Columns.Add("GreaduationYear", DbType.String);
                dt.Columns.Add("Major", DbType.String);
          Fill the data in dt from Your Data Base...then bind..
                GridView1.DataSource = dt;
                GridView1.DataBind();
