    protected void Button1_Click(object sender, EventArgs e)
    {
        string output;
        if (_dictionary.TryGetValue(TextBox1.Text, out output))
        {
            TextBox2.Text = output;
        }
        else
        {
            TextBox2.Text = "Input not recognised";
        }
    }
