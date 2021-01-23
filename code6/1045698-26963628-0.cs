    // Making the assumption here that the method is a button's Click event handler
    private async void button1_Click(object sender, EventArgs e)
    {
        _totalProcessFileProgressBar.Minimum = 0;
        _totalProcessFileProgressBar.Maximum = FileList.Length;
        _totalProcessFileProgressBar.Value = 0;
        int fileCounter = 1;
        foreach (string File in FileList)
        {
            await Task.Run(() => Program.move(File,
                _destinationFolder.SelectedPath + System.IO.Path.GetFileName(File),
                (fileCounter++) + " / " + FileList.Length));
            Trace.write(File);
            ++_totalProcessFileProgressBar.Value;
        }
    }
