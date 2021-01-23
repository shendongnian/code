    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        string grpId = ((RadioButton)sender).GroupName;
        int questionId = 0;
    
        int.TryParse(grpId.Split('_')[1].ToString(), out questionId);
    
        //Use questionId
    }
