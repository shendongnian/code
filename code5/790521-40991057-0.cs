    //Event CheckedChanged of checkbox:
    private void checkBox6_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        if (cb.CheckState == CheckState.Checked)
        {
            checkboxSelect(cb.Name);
        }
        }
    //Function that will check the state of all checkbox inside the groupbox
    private void checkboxSelect(string selectedCB)
    {
        foreach (Control ctrl in groupBox1.Controls)
        {
            if (ctrl.Name != selectedCB)
            {
                CheckBox cb = (CheckBox)ctrl;
                cb.Checked = false;
            }
        }
    }
