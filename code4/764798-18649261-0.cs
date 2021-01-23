    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        if (!AllCheckBoxChange)
        {
            chckAll.Checked = this.Controls.OfType<CheckBox>().Where(x => x.Name != "chckAll").All(c => c.Checked);  
        }
        
    }
