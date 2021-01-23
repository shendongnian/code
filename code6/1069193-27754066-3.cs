    private void Update_Click(object sender, EventArgs e)
    {
        string scheduleID = comboBox1.SelectedItem.ToString();
        if(String.IsNullOrEmpty(scheduleID) == false)
        {
            this.SaveDetails(scheduleID);
        }
    }
