        void b1SetColor(object sender, RoutedEventArgs e)
        {
            Button b = e.Source as Button;
            b.Background = new SolidColorBrush(Colors.Red);
        }
