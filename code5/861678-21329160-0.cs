    void chkBox_CheckedChanged(object sender, EventArgs e)
    {
        var chkBox = sender as CheckBox;
        if (chk.Checked == true)
        {
            lstOne.Items.Add(chkBox.Text);
        }
        else
        {
            lstOne.Items.Remove(chkBox.Text);
        }
    }
