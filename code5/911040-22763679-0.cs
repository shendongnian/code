    foreach (DataRow dr in dt.Rows)
              {
                    int index = dt.Rows.IndexOf(dr);
                     if(index =1)
                {
                    TemplateField tF = new TemplateField();
                    tF.HeaderText = dr["COLUMN_NAME"].ToString();
                    tF.ItemTemplate = LoadTemplate("/xxxxxx.ascx");
                    GridView1.Columns.Add(tF);
                }
             }
