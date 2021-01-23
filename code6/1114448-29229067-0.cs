    public void CallDialogue()
    {
        var sfd = new SaveFileDialog();
        sfd.FileOk += ValidateName;
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            MessageBox.Show(sfd.FileName);
        }
    }
    private void ValidateName(object sender, CancelEventArgs e)
    {
        var sfd = sender as SaveFileDialog;
        var file = new FileInfo(sfd.FileName);
        if (file.Name.Contains('#'))
            e.Cancel = true;
        // i did the FileInfo Stuff to quickly extract ONLY the file name, 
        // without the full path. Thats optional of course. Just an example ;-) 
    }
