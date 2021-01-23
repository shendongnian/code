        public void AnzeigenClick(object sender, RoutedEventArgs e)
        {
            Ausgabe a = new Ausgabe();
            a.Owner = this;
            a.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            a.ShowDialog();
        }
