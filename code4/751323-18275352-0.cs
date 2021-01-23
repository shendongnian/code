    label1.Dispatcher.BeginInvoke(
          System.Windows.Threading.DispatcherPriority.Normal,
          new Action(
            delegate()
            {
              label1.Content = s;
            }
        ));
