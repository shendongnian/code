    DataTable result = new DataTable();
            result.Columns.Add("datestamp", typeof(String));
            result.Columns.Add("name_x_data", typeof(String));
            result.Columns.Add("name_y_data", typeof(String));
            DataRow drresult;
            foreach (DataRow datarow in dt.Rows)
            {
                for (int i = 1; i <= dt.Columns.Count / 2; i++)
                {
                    drresult = result.NewRow();
                    drresult["datestamp"] = datarow["datestamp"];
                    drresult["name_x_data"] = datarow["name_X_" + i];
                    drresult["name_y_data"] = datarow["name_Y_" + i];
                    result.Rows.Add(drresult);
                }
            }
