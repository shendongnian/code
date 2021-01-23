    foreach (string item in Processes)
    {
      ItemValue = item;
      //Get process code for the process under the selected source
      GetActiveProcess();
      GetStartTime();
      UpdateDownloadStartTime();
      switch (ProcessCode)
      {
        case "Download File":
          await Task.Run(DownloadFile);
          break;
        case "Unzip File":
          await Task.Run(ExtractFile);
          break;
      }
      GetEndTime();
      GetDuration();
      UpdateDownloadEndTime();
    }
