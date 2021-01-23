        public void AnzeigenClick(object sender, RoutedEventArgs e)
        {
            Ausgabe a = new Ausgabe();
            a.SelectedValue = DGrid.SelectedValue as Auto;
            a.Owner = this;
            a.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            a.Setup(); // to do
            a.ShowDialog();
        }
