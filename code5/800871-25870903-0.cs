        foreach (GridViewRow row in tempGrid.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Controls.Count; i++)
            {
                Control control = row.Controls[i];
                if (control.Controls.Count==1)
                {
                    CheckBox chk = row.Cells[i].Controls[0] as CheckBox;
                    if (chk != null && chk.Checked)
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = "True";
                    }
                    else
                    dt.Rows[dt.Rows.Count - 1][i] = "False";
                }
                else
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&nbsp;", "");
            }
        }
