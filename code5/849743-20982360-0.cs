    c = float.Parse(size.Text);
    c /= 1024;
    if(c < 1024) 
    {
       size.Text = c.ToString("0.00") + " KB";
    }
    else
    {
       c /= 1024;
       size.Text = c.ToString("0.00") + " MB";
    }
