    private void NegateButton_Click(object sender, EventArgs e)
    {
        if(NumBox1.Text.StartsWith("-"))
        {
            //It's negative now, so strip the `-` sign to make it positive
            NumBox1.Text = NumBox1.Text.Substring(1);
        }
        else if(!string.IsNullOrEmpty(NumBox1.Text) && decimal.Parse(NumBox1.Text) != 0)
        {
            //It's positive now, so prefix the value with the `-` sign to make it negative
            NumBox1.Text = "-" + NumBox1.Text;
        }
    }
