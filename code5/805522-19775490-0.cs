    private void button2_Click(object sender, EventArgs e)
    {
        Thread t1 = new Thread(new ThreadStart(setColours));
        t1.IsBackground = true;
        t1.Start();
    }
    private void setColours()
    {
        foreach (Color b in new ColorConverter().GetStandardValues())
        {
            setColor(b);
            Thread.Sleep(200);
        }
    }
    delegate void setColorDelegate(Color b);
    private void setColor(Color b)
    {
        if (IsDisposed)
        {
            return;
        }
        if (InvokeRequired)
        {
            Invoke(new setColorDelegate(setColor), b);
        }
        else
        {
            button1.BackColor = b;
        }
    }
