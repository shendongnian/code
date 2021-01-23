    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                sb.Append(row.Cells[2].Text);
            }
        }
        string bS = sb.ToString();
    }
