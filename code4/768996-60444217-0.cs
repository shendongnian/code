            for (int i = 0; i < ur_grid.Rows.Count; i++)
            {
                for (int j = 0; j < ur_grid.Rows[i].Cells.Count; j++)
                {
                    if (!string.IsNullOrEmpty(ur_grid.Rows[i].Cells[j].Text.ToString()))
                    {
                        if (j > 0)
                            string_value= string_value+ "," + ur_grid.Rows[i].Cells[j].Text.ToString();
                        else
                        {
                            if (string.IsNullOrEmpty(string_value))
                                string_value= ur_grid.Rows[i].Cells[j].Text.ToString();
                            else
                                string_value= string_value+ Environment.NewLine + ur_grid.Rows[i].Cells[j].Text.ToString();
                        }
                    }
                }
            }
            string where_to_save_file = @"d:\location\Files\sample.csv";
            File.WriteAllText(where_to_save_file, string_value);
            string server_path = "/site/Files/sample.csv";
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(server_path));
            Response.WriteFile(server_path);
            Response.End();
