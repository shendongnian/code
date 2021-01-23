    private async void OnButtonClick(object sender, ...)
    {
      if (chkContacts.IsChecked.Value)
      {
          SystemTray.ProgressIndicator.Text = "Searching contacts...";
          await Task.Run(UploadImages);
      }
      if (chkImages.IsChecked.Value)
      {
          SystemTray.ProgressIndicator.Text = "Compressing images...";
          await Task.Run(UploadContacts);
      }
    }
