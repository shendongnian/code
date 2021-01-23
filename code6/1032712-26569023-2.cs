    private void btnSendURL_MouseClick(object sender, EventArgs e)
    {
     
        ApplicationService url = new ApplicationService();
        string data = url.GetURL();
        listBox1.Items.AddRange(addCopy.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
    }
