    int x, y;
           
    if (int.TryParse(txtXvalue.Text, out x) && int.TryParse(txtYvalue.Text, out y))
    {
        Location = new Point(Math.Abs(x), Math.Abs(y));
    }
    else
    {
        MessageBox.Show("Must be an Integer");
    }
