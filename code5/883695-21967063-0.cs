    foreach (TableRow row in yourTable.Rows)
    {
        foreach (TableCell cell in row.Cells)
        {
            Button btn = new Button();
            btn.Text = "Some Button";
            btn.Click += new EventHandler(btn_Click);
            cell.Controls.Add(btn);
        }
    }
