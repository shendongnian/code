    MouseEnter_handler(object sender, EventArgs e)
    {
        Button MyButton = sender as Button;
        StopWatch sw = new StopWatch();
        sw.Start();
        while (sw.ElapsedMilliseconds < 1000)
        {}
        MyButton.Enabled = true;
    }
