            while (dr.Read())
            {
                for (int k = 0; k < columncount; k++)
                {
                    switch (dr.GetFieldType(k).ToString())
                    {
                        case "System.Int32":
                            rowdata[k] = dr.GetInt32(k).ToString();
                            break;
                        case "System.DateTime":
                            rowdata[k] = dr.GetDateTime(k).ToString();
                            break;
                        case "System.String":
                            rowdata[k] = dr.GetString(k);
                            break;
                    }
                    //dataGridView1.Rows.Add(rowdata); <= This shouldn't be here
                }
              //Add row after loop completes all columns
              dataGridView1.Rows.Add(rowdata);
            }
