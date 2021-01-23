    public string Mypath;
    private void Form1_Load(object sender, EventArgs e)
    {
        DialogResult result = folderBrowserDialog1.ShowDialog();
        if (result == DialogResult.OK)
            Mypath = folderBrowserDialog1.SelectedPath;
        if (Mypath != "")
            CheckFOlder();
    }
    private void CheckFOlder()
    {
        try
        {
            var foldersToCreate = Directory.GetDirectories(Mypath, "*", SearchOption.AllDirectories);
        }
        catch (IOException e)
        {
            MessageBox.Show(e.Message.ToString());
        }
        catch (UnauthorizedAccessException e)
        {
            MessageBox.Show(e.Message.ToString());
        }
    }
