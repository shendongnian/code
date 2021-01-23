            DataTable dt = new DataTable();
            dt.Columns.Add("Year");
            dt.Columns.Add("Month");
            dt.Columns.Add("Views");
            for (int year = 2011; year < 2015; year++)
            {
                for (int month = 1; month < 13; month++)
                {
                    DataRow newRow = dt.NewRow();
                    newRow[0] = year;
                    newRow[1] = month;
                    newRow[2] = 0;
                    dt.Rows.Add(newRow);
                }
            }
            dataGridView1.DataSource = dt;
            //if using Lambda 
            //var test = dt.AsEnumerable().Where(x => x.Field<string>("Year") == "2013" && x.Field<string>("Month") == "2").ToList();
            var test = (from x in dt.AsEnumerable()
                        where x.Field<string>("Year") == "2013"
                        where x.Field<string>("Month") == "2"
                        select x).ToList();
            test[0][0] = "2015";
            dt.AcceptChanges();
