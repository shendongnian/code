    Try
    {
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
           var x = dbAllFiles.Skip(p * GlobalSettings.PageSize.myPictures)
                  .Take(GlobalSettings.PageSize.myPictures);
           foreach (var toAddObject in x)
           {
              this.allFiles.Add(toAddObject);
           }
           IsLoading = false;
        });
    }
    catch (Exception e)
    {
       Deployment.Current.Dispatcher.BeginInvoke(() =>
       {
        MessageBox.Show("Network error occured " + e.Message);
       });
    }
