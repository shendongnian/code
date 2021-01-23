    int sum = 0;
    foreach(Control ctrl in this.Controls)
    {
        if((ctrl as TextBox) != null)
        {
            TextBox txt = ctrl as TextBox;
            int val = int.Parse(txt.Text);
            sum += val;
        }
    }
