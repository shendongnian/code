    private void onRightClick(object sender, MouseEventArgs e)
    {
        stopwatch.Reset();
        stopwatch.Start();
    }
    private void onMouseUp (object sender, MouseEventArgs e)
    {
        stopwatch.Stop();
        String msg = "Duration in seconds: " + (stopwatch.ElapsedMilliseconds / 1000.0).ToString("0.00");
        MessageBox.Show(msg);
    }
