    List<CheckBox> buttonList = new List<CheckBox>();
    void NewNoiseButton_Click(object sender, EventArgs e) {
        var cb = new CheckBox();
        buttonList.Add(cb);
   
        cb.Location = new Point(2, buttonList.Count * 30 - 30);
        allNoisePanel.Controls.Add(cb);
        cb.CheckedChanged += cb_CheckedChanged;
    }
    void cb_CheckedChanged(object sender, EventArgs e) {
        CheckBox cb = sender as CheckBox;
        if(cb.Checked)
            checkboxIsChecked(cb);
        else
            checkboxIsUnchecked(cb);
    }
    void checkboxIsChecked(CheckBox checkBox) {
        //How do I make this code run?
    }
    void checkboxIsUnchecked(CheckBox checkBox) {
        //How do I make this code run?
    }
