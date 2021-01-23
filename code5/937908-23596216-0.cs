    Checkbox[] checkboxes;    
    public void FormInitializationOrWhatever()
    {
        Checkbox checkboxName1 = new CheckBox(), checkboxName2 = new CheckBox(), ...
        this.checkboxes = new CheckBox[] { checkboxName1, checkboxName2, ... };
        foreach (CheckBox cb in this.checkboxes)
        {
            cb.CheckedChanged += onSomeCheckboxWasClicked;
        }
    }    
    void onSomeCheckboxWasClicked(object sender, EventArgs e)
    {
        progress = (int)(((float)this.checkboxes.Count(cb => cb.Checked) / this.checkboxes.Length) * 100);
    }
