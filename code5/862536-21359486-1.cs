    private async void StartButton_Click(object sender, EventArgs e)
    {
      var progress = new Progress<FullOrder>(transaction =>
      {
          lastOrderId.Text = transaction.OrderId;
      });
      await Task.Run(() => Logic.GenerateStack(stackSettings, progress));
      MessageBox.Show("Completed!");
    }
