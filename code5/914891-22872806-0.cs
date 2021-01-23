    public async Task TaskDelayTestAsync(CancellationToken token)
    {
      for (int i = 0; i < 100; i++)
      {
        textBox1.Text = i.ToString();
        await Task.Delay(TimeSpan.FromSeconds(1), token);
      }
    }
