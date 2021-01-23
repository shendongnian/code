    protected void TextBox1_Validate(object sender, ServerValidateEventArgs e)
    {
        if (!CheckBox1.Checked)
        {
            e.IsValid = true;
            return;
        }
         //TODO:  Perform some validation on TextBox1 since the checkbox is checked.
    }
    protected void TextBox2_Validate(object sender, ServerValidateEventArgs e)
    {
        if (CheckBox1.Checked)
        {
            e.IsValid = true;
            return;
        }
        //TODO:  Perform some validation on TextBox2 since the checkbox is not checked.
    }
You can get the value of the respective TextBox using args.Value if you use the CustomValidator per TextBox approach I'm suggesting.
