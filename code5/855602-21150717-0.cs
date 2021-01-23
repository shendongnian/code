    private void buttonGetDeptCount2_Click(object sender, EventArgs e)
    {
        MessageBox.Show(GetScalarVal("http://localhost:28642/api/departments/Count"));
    }
    private string GetScalarVal(string uri)
    {
        var client = new WebClient();
        return client.DownloadString(uri);
    }
