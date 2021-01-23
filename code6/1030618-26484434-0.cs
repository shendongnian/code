    string myCmdText = "SELECT * FROM Parts";
    string myCmdText2 = "SELECT * FROM Types";
    int yourDropdownIndex = 2;
    MySqlCommand myQuery = new MySqlCommand(myCmdText, myConnection);
    MySqlCommand myQuery2 = new MySqlCommand(myCmdText2, myConnection);
    using (MySqlDataAdapter myAdapter = new MySqlDataAdapter(myQuery))
    using (MySqlDataAdapter myAdapter2 = new MySqlDataAdapter(myQuery2))
    {
        DataSet DS = new DataSet();
        myAdapter.Fill(DS);
        myAdapter2.Fill(DS);
        myDataGridView.DataSource = DS.Tables[0];
        foreach (DataGridViewRow row in myDataGridView.Rows)
        {
            var temp = row.Cells[yourDropdownIndex].Value;
            DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
            comboCell.DataSource = DS.Tables[1];
            row.Cells[yourDropdownIndex] = comboCell;
            row.Cells[yourDropdownIndex].Value = temp;
        }
    }
