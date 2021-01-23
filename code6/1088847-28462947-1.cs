    public sealed partial class MapControl : UserControl
    {
        public MapControl()
        {
            this.InitializeComponent();
        }
        private async void pushpinTapped(object sender, TappedRoutedEventArgs e)
        {
            Pushpin p = sender as Pushpin;
            Infobox.Visibility = Visibility.Visible;
            MapLayer.SetPosition(Infobox, MapLayer.GetPosition(p));
        }
        private void CloseInfobox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Infobox.Visibility = Visibility.Collapsed;
        }
        private void Map_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            if (DataLayer.Children != null)
                foreach (var pin in DataLayer.Children)
                {
                    pin.Tapped += pushpinTapped;
                }
        }
    }
