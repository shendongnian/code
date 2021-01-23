    if(lines.Length == 5)
    {
        tbOpenKey.Text = lines[0];
        tbSecretKey.Text = lines[1];
        tbStatusRequestPath.Text = lines[2];
        tbStatusRequestAPI.Text = lines[3];
        tbSeconds.Text = lines[4];
    }
    else
    {
        MessageBox.Show("Input Data is Wrong");
    }
