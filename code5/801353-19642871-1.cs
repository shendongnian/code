    private void btnDisplay_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= 10; i++)
        {
            TableRow tr = new TableRow();
            tblProduct.Rows.Add(tr);
            TableCell td = new TableCell();
            td.Text = i.ToString();
            tr.Cells.Add(td);
            for (int j = 1; j <= 10; j++)
            {
                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = (i * j).ToString;
            }
        }
    }
