    class MenuItem : Label
    {
        public bool IsParentBusy { get; set; }
    }
    // I.e. some method where you are handling the BackgroundWorker
    void button1_Click(object sender, EventArgs e)
    {
        // ...some other initialization...
        bwRefreshGalleries.RunWorkerCompleted += (sender1, e1) =>
        {
            menuItem1.IsParentBusy = false;
        };
        menuItem1.ParentIsBusy = true;
        bwRefreshGalleries.RunAsync();
    }
