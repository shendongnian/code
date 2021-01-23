    private void button2_Click(object sender, EventArgs e)
    {
        Thread t1=new Thread(new ThreadStart(setColours));
        t1.Start();
    }
    private void setColours()
    {
        foreach (Color b in new ColorConverter().GetStandardValues())
        {
            button1.BackColor = b;
            Thread.Sleep(200);
        }
    }
