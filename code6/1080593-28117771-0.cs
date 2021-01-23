    private CancellationTokenSource _cancelSource;
    private void stopButton_Click(object sender, EventArgs e)
    {
        if (_cancelSource != null)
        {
            _cancelSource.Cancel();
        }
    }
    private async void startButton_Click(object sender, EventArgs e)
    {
        using (CancellationTokenSource cancelSource = new CancellationTokenSource)
        {
            _cancelSource = cancelSource;
            try
            {
                foreach (string[] conn in lines)
                {
                    string connectionString = conn[0];
                    FbConnection fbConn = new FbConnection(connectionString);
                    fbConn.Open();
                    try
                    {
                        await getDocuments(fbConn, cancelSource.Token);
                        await getArticles(fbConn, cancelSource.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        return;
                    }
                    finally
                    {
                        fbConn.Close();
                    }
                }
            }
            finally
            {
                _cancelSource = null;
            }
        }
    }
    private async Task getDocuments(FbConnection fbConn, CancellationToken cancelToken)
    {
        DataTable dt = await Task.Run(() => getNewDocuments(fbConn));
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            cancelToken.ThrowIfCancellationRequested();
            await Task.Run(() => sendDocumentsToMySQL((int)dt.Rows[i]["ID"]));
        }
    }
    private async Task getArticles(FbConnection fbConn, CancellationToken cancelToken)
    {
        DataTable dt = await Task.Run(() => getNewArticles(fbConn));
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            cancelToken.ThrowIfCancellationRequested();
            await Task.Run(() => sendArticlesToMySQL((int)dt.Rows[i]["ID"]));
        }
    }
