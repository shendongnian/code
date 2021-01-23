    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        _myTimer.Stop();
        _myTimer.Dispose();
    }
    private void TOnTick(object sender, EventArgs eventArgs)
    {
        //_myTimer.Stop();
        //_myTimer.Dispose();  No need to call, as it will be redundant
        Close();   // Will call FormClosed
    }
