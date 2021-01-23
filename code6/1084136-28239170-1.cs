    Try(async () => await Task.Factory.StartNew(() =>
        {
            SharePointService.Connect(Connection);
            IsConnected = true;
        }));
