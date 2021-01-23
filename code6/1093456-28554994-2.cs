     private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string senderToString = sender.ToString();
            Button yourClickedButton = sender as Button;
            yourClickedButton.Background = Brushes.AliceBlue ;
            x = x.Remove(0, x.Length - 3);
        }
