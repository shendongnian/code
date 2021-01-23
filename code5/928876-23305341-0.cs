    public class MyControl
    {
        private RoutedEventHandler _handler;
 
        public void Subscribe()
        {
            _handler = (sender, args) => AddColumns(dataGrid, GetAttachedColumns(dataGrid));
            dataGrid.Loaded -= _handler;
        }
        public void Unsubscribe()
        {
            dataGrid.Loaded -= _handler;
        }
    }
