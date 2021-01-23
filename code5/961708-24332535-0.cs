    private void onClick_Handler(object sender, EventArgs e) {
        //disable button here
        Task.Factory.StartNew(() => {
            Process p = Process.Start("IExplore");
            p.WaitForExit();
            //enable button here. make sure to do this on the UI thread
            //since you're doing this in the code-behind you should have access
            //to the dispatcher
            Dispatcher.BeginInvoke((Action)OnUpdateUI);
        });            
    }
    private void OnUpdateUI(){
    }
