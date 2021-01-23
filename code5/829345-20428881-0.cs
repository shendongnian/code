     TemplateField tF = new TemplateField();
                        // tF.HeaderText = dr["COLUMN_NAME"].ToString();
                        tF.HeaderText = col.ToString();
                        tF.ItemTemplate = LoadTemplate("~/xxxxxxx.ascx");
                        grdVw.Columns.Add(tF);
