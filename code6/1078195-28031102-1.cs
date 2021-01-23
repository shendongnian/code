    async void BtnRunProcessClick(object sender, System.EventArgs e)
    {
      cts = new CancellationTokenSource();
      using (var progress = ObservableProgress<double>.CreateForUi(value =>
        {
          TextBox1.Text = string.Format("{0:0} s", pendingTime / 1000);
        }))
      {
        await Task.Run(() => Function1(filename, cts.Token), cts.Token, progress);
      }
    }
