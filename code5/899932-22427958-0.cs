    // this is called from any thread
    public void videoImage(Image image)
    {
        // are we called from the UI thread?
        if (this.InvokeRequired)
        {
            // no, so call this method again but this
            // time use the UI thread!
            // the heavy-lifting for switching to the ui-thread
            // is done for you
            this.Invoke(new MethodInvoker(delegate { videoImage(image); }));
        }
        // we are now for sure on the UI thread
        // so update the image
        this.VideoViewer.Image = image;
    }
