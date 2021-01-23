    foreach (DataRow row in dt1.Rows)
    {
        string name = row["TABLE_NAME"].ToString();
        var tabPage = new TabPage(name);
        DataGridView grid = new DataGridView {
            Dock = DockStyle.Fill
        };
        tabPage.Controls.Add(grid);
        comboBox1.Items.Add(name);
        tabControl2.TabPages.Add(tabPage);
    }
