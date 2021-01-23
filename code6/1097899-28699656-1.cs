    private async void button1_Click(object sender, EventArgs e)
    {
      IProgress<string> progress = new Progress<string>(update =>
      {
        listBox1.Items.Add(s);
        btIniciar1.Enabled = false;
      });
      var ts = await Task.Run(() => Parallel.ForEach( ...
      ));
      btIniciar1.Enabled = true;
      textBox1.Text = ts.ToString("mm\\:ss\\.ff") + (" minuts");
    }
