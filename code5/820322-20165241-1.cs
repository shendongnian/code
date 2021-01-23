    _fileSysWatcher.Created += (sender, e) =>
          {
              App.Current.Dispatcher.Invoke((Action)delegate
              {
                  _fileMonitorEntries.Add(new FileMonitor
                  {
                     FileName = e.Name,
                     FilePath = e.FullPath
                  });
              });
          };
