    private void YourComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        string item = (string)YourComboBox.SelectedItem;
        //Fetch data (dummy method)
        Employee emp = GetDataByName(item);
        //Write to TextBox
        SomeTextBox.Text = emp.Function;
    }
