    private void OnClose(object sender, CancelEventArgs e){
            try
            {
                var process = Process.GetCurrentProcess();
                process.Kill();
                //HubConnection.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
    }
