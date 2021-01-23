    if (e.CommandName == "btnSave")
    {
        int j = 0;
        foreach (DetailsViewRow row in DetailsView1.Rows)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                TextBox tb = FindControl<TextBox>(row.Cells[i].Controls);
                if (tb != null)
                {
                    table.Rows[0][j] = tb.Text;
                }
                CheckBox cb = FindControl<CheckBox>(row.Cells[i].Controls);
                if (cb != null)
                {
                    table.Rows[0][j] = cb.Checked;
                }
            }
            j++;
        }
