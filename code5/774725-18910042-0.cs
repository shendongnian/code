     public static void ConvertGridToTable(ref DataTable dt, ref GridView grd)
        {
            try
            {
                if (grd.Rows.Count <= 0) return;
                for (int i = 0; i <= grd.Columns.Count - 1; i++)
                {
                    if (grd.Columns[i].GetType().Name.Equals("BoundField"))
                    {
                        BoundField bf = (BoundField)grd.Columns[i];
                        dt.Columns.Add(bf.DataField.ToString());
                    }
                }
                for (int i = 0; i <= grd.Rows.Count - 1; i++)
                {
                    dt.Rows.Add();
                    for (int j = 0; j <= grd.Columns.Count - 1; j++)
                    {
                        if (grd.Columns[j].GetType().Name.Equals("BoundField"))
                        {
                            BoundField bf = (BoundField)grd.Columns[j];
                            for (int k = 0; k <= dt.Columns.Count - 1; k++)
                            {
                                if (dt.Columns[k].ColumnName.Trim().Equals(bf.DataField.ToString()))
                                {
                                    string value = grd.Rows[i].Cells[j].Text.Trim().Contains("&nbsp;") ? grd.Rows[i].Cells[j].Text.Trim().Replace("&nbsp;", string.Empty) : grd.Rows[i].Cells[j].Text.Trim();
                                    dt.Rows[i][bf.DataField.ToString()] = value;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
