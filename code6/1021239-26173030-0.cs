    //Set 1 in the Tag property after loading data
    private void LoadData()
    {
        textBox1.Text = myValue;
        textBox1.Tag = 0;
    }
    //Set 0 in the Tag property on TextChange
    private void textBox1_TextChange(object sender, EventArgs)
    {
        ((TextBox)sender).Tag = 1;
    }
    //Check if Tag != 0 then do your stuff.
    private void button1_click(object sender, EventArgs e)
    {
        if (textBox1.Tag != null && Convert.ToInt32(textBox1.Tag) != 0)
        {
             MessageBox.Show("The text box has been changed since you tested it are you sure you want to submit this to production", "Value Has Changed");
        }
    }
