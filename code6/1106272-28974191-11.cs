    BindingSource BS = new BindingSource();
    private void sortButton_Click(object sender, EventArgs e)
    {
        DT.Columns.Add("TempSort");
        foreach (DataRow row in DT.Rows)
        {
            string val = row[yourcolumn].ToString();
            row["TempSort"] = val.ToString().Substring(0, 6) + 
                              val.ToString().Substring(6).PadLeft(5, '0');
        }
        BS.DataSource = DT;
        BS.Sort = "TempSort ASC";
        DT.Columns.Remove("TempSort");
        DGV.DataSource = BS;
    }
