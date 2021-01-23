    private void GetDataBase_FormClosed(object sender, FormClosedEventArgs e)
    {
        _myTimer.Stop();
        _myTimer.Dispose();
        //Close(); No need for close, as it is already in the closing-process
    }
    private void TOnTick(object sender, EventArgs eventArgs)
    {
        //_myTimer.Stop();
        //_myTimer.Dispose();  Remove those steps, as it would close every form
        //Close();             after 10 seconds.
    }
