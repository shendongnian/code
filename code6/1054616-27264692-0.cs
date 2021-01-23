    private async void frmProgressBar_Load(object sender, EventArgs e)
    {
        if (_commonDAC == null)
            _commonDAC = new CommonDAC();  
    
        this.ServiceProgressBar.Visible = true;
        // Calling my store procedure 
        int result = await Task.Run(() => _commonDAC.RebalanceClient());
        this.ServiceProgressBar.Visible = false;
        //progressBar1.Style = ProgressBarStyle.Blocks;
    }
