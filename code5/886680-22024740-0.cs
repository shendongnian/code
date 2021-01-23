    private const int DelayMilliseconds = 500;
    private void Form1_Load(object sender, EventArgs e)
    {
        new System.Threading.Timer(_ => Invoke(new Action(() => _myLabel.Text = "bla")),
                                   null,
                                   DelayMilliseconds,
                                   Timeout.Infinite);
    }
