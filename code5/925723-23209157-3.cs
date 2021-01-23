    private void radioButton_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton currentrb = (RadioButton)sender;
        if(currentrb.Checked)
        {
            switch(currentrb.Parent.Name)
            {
                case "GroupBox1":
                    result1 = decimal.Parse(currentrb.Text);
                    break;
                case "GroupBox2":
                    result2 = decimal.Parse(currentrb.Text);
                    break;
                case "GroupBox3":
                    result3 = Int16.Parse(currentrb.Text);
                    break;
            }
        }
    }
