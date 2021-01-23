    protected void OnDataBound(object sender, EventArgs e)
    {
        int RowSpan = 2;
        // actual row counter, spanned rows count as one
        int rowCount = 0;
        for (int i = visualisation.Rows.Count - 2; i >= 0; i--)
        {
            GridViewRow currRow = visualisation.Rows[i];
            GridViewRow prevRow = visualisation.Rows[i + 1];
            if (currRow.Cells[0].Text == prevRow.Cells[0].Text)
            {
                currRow.Cells[0].RowSpan = RowSpan;
                prevRow.Cells[0].Visible = false;
                RowSpan += 1;
            }
            else
            {
                RowSpan = 2;
                //it was a new row
                rowCount++;
            }
            if (rowCount % 2 == 0)
            {
                currRow.BackColor = Color.FromName("#7AA5D6");            
            }
        }
    }
