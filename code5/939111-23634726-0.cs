    private void myMethod(CancellationToken token)
    {
        using (var lFileStream = File.Open(aDestinationFile, shouldResume ? FileMode.Append : FileMode.Create, FileAccess.Write))
        {
            try
            {
                while ((lCount = lDownloadStream.Read(lBuf, 0, lBuf.Length)) > 0)
                {
                    token.ThrowIfCancellationRequested();
                    lFileStream.Write(lBuf, 0, lCount);
                }
            }
            finally
            {
                lFileStream.Close();
            }
        }
    }
    Task.Factory.StartNew(() => 
                    {
                        try
                        {
                            myMethod(_resetEvent.Token);
                        }
                        catch (Exception ex)
                        {
                            //If the task was canceled we don't need to log the exception.
                            if(!ex is OperationCanceledException)
                                Log.Exc(ex);
                        }
                    }
                , _resetEvent.Token);
