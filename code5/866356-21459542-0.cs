    private void CheckEveryOther_Click(object sender, System.EventArgs e)
    {
        {Control}.{ControlsEvent} -= new  EventHandler(CheckEveryOther_Click);
        for (int i = 0; i < checkedListBox1.Items.Count; i++)
        {
            var state = checkedListBox1.GetItemCheckState(i);
    
            if (state != CheckState.Checked && state != CheckState.Indeterminate)
            {
                 checkedListBox1.SetItemCheckState(i, CheckState.Indeterminate);
            }
        } 
        {Control}.{ControlsEvent} += new  EventHandler(CheckEveryOther_Click);     
    }
