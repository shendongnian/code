       private void cmdSend_Click(object sender, System.EventArgs e)
        {
            List<string>[] list;
            list = dbConnect.Select(cmdSendMonth.SelectedItem.ToString(),cmbYear.SelectedItem.ToString());
        
            //submit the value month and year to dbConnect.select class.
        } 
