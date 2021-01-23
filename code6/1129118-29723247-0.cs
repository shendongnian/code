    foreach(IBackgroundTaskRegistration task in BackgroundTaskRegistration.AllTasks.Values)
    {
       if ((task as BackgroundTaskRegistration).Name == myTaskName)
       {
          if (await IsFilePresentInLocalDirectory("TaskCancelling.txt"))
          {
             //Task registration is present, but task isn't actually running.
             //Unregister the useless task
             (task as BackgroundTaskRegistration).Unregister();
             //Delete the file
             StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("TaskCancelling.txt");
             await file.DeleteAsync();
             //Relaunch the DeviceUseTrigger task
             RelaunchBackgroundTask();
          }
       }
    }
    private async Task<bool> IsFilePresentInLocalDirectory(string fileName)
    {
       try
       {
          StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
          return true;
       }
       catch (Exception exc)
       {
          return false;
       }
    }
