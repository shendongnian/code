        Dispatcher.BeginInvoke(() =>
        {
            IsolatedStorageSettings.ApplicationSettings["CurrentLocationAdded"] = true;
            obj.Start();
            RetrieveFormatedAddress(obj.Position.Location.Latitude.ToString(), obj.Position.Location.Longitude.ToString());
        });
