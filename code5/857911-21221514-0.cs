    new Task(() =>
    {
         Task.Factory.StartNew(Counter1);
         Task.Factory.StartNew(Counter2);
    }).Start();
    private void Counter2()
    {
        for (int i = 0; i < 30; i++)
        {
            Thread.Sleep(500);
            label2.Text = i.ToString();
        }
    }
    private void Counter1()
    {
        for (int i = 0; i < 30; i++)
        {
            Thread.Sleep(500);
            label3.Text = i.ToString();
            if(i == 15)
                Thread.Sleep(3000);
        }
    }e
