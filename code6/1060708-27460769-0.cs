    foreach (var item in checkedListBox1.CheckedItems)
    {
        foreach (string subName in (item.ToString().Split('+')))
        {
            SQLString2 = "UPDATE subjects SET program = '" + program + "', faculty = '" + faculty + "', subjectN = '" + subName + "' WHERE RollNo = " + rollNumber + " AND regYear = " + regNumber + " AND program = '" + this.comboBox1.SelectedItem.ToString() + "' AND faculty = '" + this.comboBox2.SelectedItem.ToString() + "'";        
        }
        SQLCommand.CommandText = SQLString2;
        SQLCommand.Connection = database;
        int response2;
        try
        {
            response2 = SQLCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
