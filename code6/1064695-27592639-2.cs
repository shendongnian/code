    protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/xmldata.xml"));
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("MonopolyID", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Password", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("FirstName", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("LastName", typeof(string));
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dt.Rows.Add("User3", "pass3", "User3Name", "User3LastName");
            //dt.TableName = "Users";
            ds.Tables.Add(dt);
            //ds.DataSetName = "DATA";
            ds.Merge(dt);
            ds.WriteXml(Server.MapPath("~/xmldata.xml"));
        }
