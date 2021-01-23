    private bool _processingData = false;
    private void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {       
        if (!_processingData)
        {
            _processingData = true;
            QueryForData();
            ProcessData();
            _processingData = false;
        }
    }
