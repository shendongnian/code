    public class SyncConverter : IValueConverter
    {
        public object Synced {get;set;}
        public object Desynced{get;set;}
        public object Syncing{get;set;}
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case SyncStatus.Synced:
                    return Synced;
                case SyncStatus.Desynced:
                    return Desynced;
                case SyncStatus.Syncing:
                    return Syncing;
            }
        }
     
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            return null;
        }
    }
