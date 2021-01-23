    private void mnuLogging_Checked(object sender, RoutedEventArgs e) {
      int LogLevel = Convert.ToInt32( ((MenuItem)sender).Tag.ToString());
      Properties.Settings.Default["LogLevel"] = LogLevel.ToString();
      Properties.Settings.Default.Save();
      // Uncheck everybody but me (as determine by "Tag")
      for (int i=0; i < 4; i++) {
        MenuItem item = Main.FindName("mnuLogging"+i) as MenuItem;
        if (i != LogLevel) item.IsChecked = false;
      }
    }
