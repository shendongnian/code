     protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            switch (propertyName)
            {
                case "IsDownloaded":
                case "IsAvailableToUse":
                case "IsPurchased":
                    if (handler != null) handler(this, new PropertyChangedEventArgs("IsDownloaded"));
                    if (handler != null) handler(this, new PropertyChangedEventArgs("IsAvailableToUse"));
                    if (handler != null) handler(this, new PropertyChangedEventArgs("IsPurchased"));
                    break;
                default:
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
                    break;
            }
        }
