    class CustomListView: ListView
    {
        public CustomListView()
        {
            EventManager.RegisterClassHandler(typeof(CustomListView), MouseWheelEvent, new RoutedEventHandler(OnMouseWheel), true);
        }
        internal static void OnMouseWheel(object sender, RoutedEventArgs e)
        {
            //Do something you want
        }
    }
