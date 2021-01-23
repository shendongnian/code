                DataTable dt = new DataTable("Trial");
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("name", typeof(string));
                
                dt.Rows.Add(1, "ali");
                dt.Rows.Add(2, "reza");
                dt.Rows.Add(3, "mehdi");
                dt.Rows.Add(4, "alireza");
                dt.Rows.Add(4, "amirali");
                
                DataRow[] result = dt.Select("name like '*%ali%*'");
                DataTable dtnew = new DataTable();
                dtnew.Columns.Add("id", typeof(int));
                dtnew.Columns.Add("name", typeof(string));
                foreach (DataRow dr in result)
                {
                    dtnew.ImportRow(dr);
                }
                GridView1.DataSource = dtnew;    
                GridView1.DataBind();
