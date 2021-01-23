    //...
    {
      foreach (/*item to add to list*/)
      {
        Bitmap progressBarBitmap = new Bitmap(
            this.imageList.ImageSize.Width,
            this.imageList.ImageSize.Height);
        this.imageList.Images.Add(progressBarBitmap);
        ProgressBar progressBar = new ProgressBar();
        progressBar.MinimumSize = this.imageList.ImageSize;
        progressBar.MaximumSize = this.imageList.ImageSize;
        progressBar.Size = this.imageList.ImageSize;
        
        // probably create also some BackgroundWorker here with information about
        // this particular progressBar
        
        ListViewItem lvi = new ListViewItem(
            new[] { "column1", ... },
            this.listView.Items.Count);
        lvi.UseItemStyleForSubItems = true;
        this.listView.Items.Add(lvi);
        lvi.Tag = /* some convenient info class to refer back to related objects */
      }
    //...
    }
