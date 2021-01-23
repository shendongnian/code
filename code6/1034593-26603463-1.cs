    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        _myTimer.Stop();
        _myTimer.Dispose();
    }
    private void TOnTick(object sender, EventArgs eventArgs)
    {
        _myTimer.Stop();
        _myTimer.Dispose();  
        Close();   // Will call FormClosed
    }
