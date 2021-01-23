    private void StartBtn_OnClick(object sender, EventArgs e)
    {
        _isRunning = true;
        CodeIsRunning.Visibility = Visibility.Visible;
        //Anything else needed (disable buttons, etc)
        Task.Factory.StartNew(() => {
            for (var i = 0; i < 3504; i++)
                for (var j = 0; j < 2306; j++)
                { 
                    ... 
                }
            _isRunning = false;
        });
    }
