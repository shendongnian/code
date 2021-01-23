    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        if (cb.Checked)
        { Box.ChangeState(cb, true); }
        else { Box.ChangeState(cb, false); }
    }
