    async void Begin_Click(object sender, EventArgs e)//<--Note the async keyword here
    {
        Stopwatch sw = Stopwatch.StartNew();
        // Pass the token to the cancelable operation.
        cts = new CancellationTokenSource();
        await Task.Run(() => MyFunction(inputstring, cts.Token), cts.Token);//<--Note the await keyword here
        sw.Stop();
        textBox1.Text += Math.Round(sw.Elapsed.TotalMilliseconds / 1000, 4) + " sec";
    }
