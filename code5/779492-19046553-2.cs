    protected void gvList_DataBound(object sender, EventArgs e)
    {
        string oldValue = string.Empty;
        string newValue = string.Empty;
        for (int j = 0; j < 2; j++)
        {
            for (int count = 0; count < gvList.Rows.Count; count++)
            {
                oldValue = gvList.Rows[count].Cells[j].Text;
                if (oldValue == newValue)
                {
                    gvList.Rows[count].Cells[j].Text = string.Empty;
                }
                newValue = oldValue;
            }
        }
    }
