    private async void OnChangesSaved(IAsyncResult result)
    {
        bool errorFound = false;
        CoreDispatcher dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
        await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
          {
            this._context = result.AsyncState as THA001_devEntities;
            try
            {
                // Complete the save changes operation.
                this._context.EndSaveChanges(result);
            }
            catch (DataServiceRequestException ex)
            {
                errorFound = true;
                MessageBox.Show("Error, While Updating Record");
            }
            if (!errorFound)
            {
                MessageBox.Show("Record Successfully Updated");
            }
          });
    }
