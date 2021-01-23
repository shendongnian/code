    private void worker_DoWork(object sender, DoWorkEventArgs e) {
      for (int i = 1; i <= 10; i++) {
        int x = DataSupplier.GenerateRandomInt();
        Dispatcher.BeginInvoke(
          DispatcherPriority.Normal,
          (Action)(() => {
            Label lbl = new Label { Content = x };
            stackPanel1.Children.Add(lbl);
          }));
      }
    }
