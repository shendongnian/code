    // Assign this eventhandler to every button
    private void _allButton_Click(object sender, EventArgs e)
    {
        _startButton((Button) sender);
    }
    private void _startButton(Button button)
    {
        string path;
        if(_exePaths.TryGetValue(button, out path)) 
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = path;
            Process.Start(start);
        } else MessageBox.Show("No Exe for this button defined!");
    }
