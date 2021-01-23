    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckFlg = true;
        if (!CheckAllFlg)
        {
            chckAll.Checked = checkBoxesPanel3.Controls.OfType<CheckBox>().Where(x => x.Name != "chckAll").All(c => c.Checked);  
        }
        CheckFlg = false;
    }
    private void chckAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckAllFlg = true;
        if (!CheckFlg)
        {
            foreach (CheckBox ctrl in checkBoxesPanel3.Controls.OfType<CheckBox>().Where(x => x.Name != "chckAll"))
            {
                ctrl.Checked = chckAll.Checked;
            }
        }
        CheckAllFlg = false;
    }
