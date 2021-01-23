    private async void button1_Click(object sender, EventArgs e)
    {
      IProgress<string> progress = new Progress<string>(update =>
      {
        listBox1.Items.Add(s);
        btIniciar1.Enabled = false;
      });
      var ts = await Task.Run(() =>
      {
        Stopwatch stopWatch = new Stopwatch();
        foreach (string d in Directory.GetDirectories(@"C:\Visual Studio Projectes\Hash\AsyncAwait\Carpetes"))
        {
          foreach (string s in Directory.GetFiles(d))
          {
            stopWatch.Start();
            progress.Report(s);
          }
        }
        stopWatch.Stop();
        return stopWatch.Elapsed;
      });
      btIniciar1.Enabled = true;
      textBox1.Text = ts.ToString("mm\\:ss\\.ff") + (" minuts");
    }
