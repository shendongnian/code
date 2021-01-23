    BindingSource BS = new BindingSource();
    private void sortButton_Click(object sender, EventArgs e)
    {
        DT.Columns.Add("SORT");
        foreach (DataRow row in DT.Rows)
        {
            string val = row[yourcolumn].ToString();
            row["SORT"] = val.ToString().Substring(0, 6) + val.ToString().Substring(6).PadLeft(5, '0');
        }
        BS.DataSource = DT;
        BS.Sort = "SORT ASC";
        DT.Columns.Remove("SORT");
        DGV.DataSource = BS;
    }
