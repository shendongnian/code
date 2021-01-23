    int x, y;
    if (int.TryParse(txtXvalue.Text, out x) && int.TryParse(txtYvalue.Text, out y))
    {
        if (x < 0 || y < 0)
        {
            MessageBox.Show("Negative numbers not allowed");
        }
        else
            Location = new Point(x, y);
    }
    else
    {
        MessageBox.Show("Must be an Integer");
    }
