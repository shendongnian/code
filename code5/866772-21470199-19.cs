        try
        {
            await DoSocketStuffAsync(_userCancellationToken.Token);
        }
        catch (Exception ex)
        {
            while (ex is AggregateException)
                ex = ex.InnerException;
            if (ex is OperationCanceledException)
                return; // ignore if cancelled
            // report otherwise
            MessageBox.Show(ex.Message);
        }
    } 
