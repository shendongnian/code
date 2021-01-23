    private async void btnSend_Click(object sender, RoutedEventArgs e)
    {
      var quantity = int.Parse(boxQuantity.Text);
      btnSend.Enabled = false;
      await DownloadAsync(quantity);
      btnSend.Enabled = true;
    }
