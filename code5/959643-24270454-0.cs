    public void optionCheck(TextBox txt, ref string str)
    {
        if (txt.Text == "0")
        {
            str = "+++";
        }
        else
        {
            str = "---";
        }
    }
    public void checkBoxClick3(CheckBox check, ref string txt)
    {
        /* Determine the CheckState of the Checkbox */
        if (check.CheckState == CheckState.Checked)
        {
            /* If the CheckState is Checked, then set the value to 1 */
            txt = "1";
        }
        else
        {
            /* If the CheckState is Unchecked, then set the value to 0 */
            txt = "0";
        }
    }
