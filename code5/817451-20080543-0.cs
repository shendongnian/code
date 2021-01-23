    private Form1()
    {
        //Snip
        trackBar7Progress = new Progress<int>(value => trackBar7.Value = value);
        trackBar8Progress = new Progress<int>(value => trackBar8.Value = value);
        trackBar9Progress = new Progress<int>(value => trackBar9.Value = value);
    }
    IProgress<int> trackBar7Progress;
    IProgress<int> trackBar8Progress;
    IProgress<int> trackBar9Progress;
