    App.Current.Dispatcher.Invoke((Action)delegate
    {
          System.Windows.Media.Animation.Storyboard sb =
                (System.Windows.Media.Animation.Storyboard)FindResource("sbClose");
          BeginStoryboard(sb);
    });
