    private async void btnSend_Click(object sender, RoutedEventArgs e)
    {
      var quantity = int.Parse(boxQuantity.Text);
      var progress = new Progress<string>(update =>
      {
        AppendText(update);
        progressBar.Value = progressBar.Value + 1;
      });
      progressBar.Maximum = ...; // not "quantity"
      btnSend.Enabled = false;
      await DownloadAsync(quantity, progress);
      btnSend.Enabled = true;
    }
