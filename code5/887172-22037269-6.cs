    private async void OnButtonClick(object sender, ...)
    {
      bool uploadContacts = chkContacts.IsChecked.Value;
      bool uploadImages = chkImages.IsChecked.Value;
      //use this if the continuation runs on the UI thread
      Action continuation = async () {
        if(uploadImages) {
          SystemTray.ProgressIndicator.Text = "Compressing images...";
          await Task.Run(() => UploadImages());
        }
      }
      //OR this if it doesn't
      Action continuation = () {
        if(uploadImages) {
          Dispatcher.BeginInvoke(() => SystemTray.ProgressIndicator.Text = "Compressing images...");
          UploadImages();
        }
      }
      if (uploadContacts)
      {
          SystemTray.ProgressIndicator.Text = "Searching contacts...";
          UploadContacts(continuation);
      }
    }
    private void UploadContacts(Action continuation)
    {
      Contacts objContacts = new Contacts();
      
      //when the search has finished, trigger your event handler AND the continuation task, which will upload the images
      objContacts.SearchCompleted += objContacts_SearchCompleted;
      objContacts.SearchCompleted += (sender, args) => continuation();
      objContacts.SearchAsync(string.Empty, FilterKind.None, null);
    }
