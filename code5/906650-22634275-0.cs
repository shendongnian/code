    async Task DoWorkAsync()
    {
        // don't handle exceptions here
    }
    async void Form_Load(object s, EventArgs args)
    {
        try {
            await DoWorkAsync();
        }
        catch (Exception ex) 
        {
            // log
            logger.Error(ex);
            // report
            MessageBox.Show(ex.Message);
        }
    }
