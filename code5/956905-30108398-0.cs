     DataTransferManager dataTransferManager;
        private void RegisterForShare()
        {
            if (dataTransferManager == null)
            {
                dataTransferManager = DataTransferManager.GetForCurrentView();
                dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager,
                    DataRequestedEventArgs>(this.ShareStorageItemsHandler);
            }
        }
        private async void ShareStorageItemsHandler(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;
           
            // Because we are making async calls in the DataRequested event handler,
            // we need to get the deferral first.
            DataRequestDeferral deferral = request.GetDeferral();
           
            StorageFile videoStorageFile; // set this somewhere
            
            // Make sure we always call Complete on the deferral.
            try
            {
        
                List<IStorageItem> storageItems = new List<IStorageItem>();
                storageItems.Add(videoStorageFile);
                request.Data.SetStorageItems(storageItems);
            }
            finally
            {
                deferral.Complete();
            }
        }
