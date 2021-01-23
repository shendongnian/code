      public LoadImages()
        {
       BackgroundWorker BWorker = new BackgroundWorker();
            BWorker.DoWork += new DoWorkEventHandler(BWorker_DoWork);
            BWorker.RunWorkerCompleted += 
                new RunWorkerCompletedEventHandler(BWorker_RunWorkerCompleted);
            BWorker.RunWorkerAsync();
      }
       void BWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BitmapSource bitmap = e.Result as BitmapSource;
                Dispatcher.BeginInvoke(DispatcherPriority.Normal 
                    (ThreadStart)delegate()
                {
                    Image image = new Image();
                    image.Source = bitmap;
                    background.Child = image;
                 });
        }
        void BWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BitmapSource bitmapSource = IMAGEFROMFILE;
            e.Result = bitmapSource;
         }
