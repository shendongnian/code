    foreach (DataRow row in dt1.Rows) {
        string name = row["TABLE_NAME"].ToString();
        var tabPage = new TabPage(name);
        var grid = new DataGridView();
        tabPage.Controls.Add(grid);
        comboBox1.Items.Add(name);        
        tabControl2.TabPages.Add(tapPage);
    }
