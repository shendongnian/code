    private void button1_Click(object sender, EventArgs e)
    {
        
        for (int i = 0; i < 3; i++)
        {
            int tasknumber = test;
            Task t = Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(5000);
                return tasknumber;
        
            }).ContinueWith(o =>
            {
                listBox1.Items.Add(o.Result);
            }, TaskScheduler.FromCurrentSynchronizationContext());
            test++;
        }
    }
