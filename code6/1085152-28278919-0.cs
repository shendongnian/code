    int versionNumber = 1000;
    public void versionIncrement()
    {
        versionNumber++;
        lblOutput.Text = versionNumber.ToString();
        lblOutput.Visible = true;
    }
