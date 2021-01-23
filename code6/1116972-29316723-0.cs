    public void radiobutton_Checked(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            var tag = Convert.ToInt32(rb.Tag);
            angle_Offset = (degrees_90 * tag) - Heading;
        }
     protected void textbox_TextChanged(object sender, EventArgs e)
        {
            RadioButton rb = .. // get the radiobutton checked
            radiobutton_Checked(rb , null);
        }
