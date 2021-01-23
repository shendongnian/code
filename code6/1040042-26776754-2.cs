    Task<bool> pendingDownload = null;
    
    private async void mainMethod(...) {
        if(pendingDownload != null) {
            MessageBox.Show("Image is not ready!");
            return;
        }
        try{
            pendingDownload = myMethod(...);
            bool isReady = await  pendingDownload;
            MessageBox.Show("Bitmap downloaded");
        } catch(Exception e) {
             MessageBox.Show("Error in downloading image: " + ex.Message);
        }
        pendingDownload = null;
    }
