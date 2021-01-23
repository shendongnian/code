    private void ButtonOK_Click(object sender, EventArgs e)
    {
        string a = textbox1.Text;
        int b;
        if (Int32.TryParse(a, out b))
        {
            label1.Text = b.ToString();       
        }
    }
