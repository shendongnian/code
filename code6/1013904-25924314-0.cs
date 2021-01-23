    delegate void Work();
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        new Work(WorkOne).BeginInvoke(null, null);
    }
    
    private void WorkOne()
    {
        int x = 0;
        while (r == false)
        {
            listBox.Dispatcher.Invoke(new Action(() =>{ listBox.Items.Add(x++); }));
            System.Threading.Thread.Sleep(x);
        }
    }
    
    private void btnStop_Click(object sender, RoutedEventArgs e)
    {
            r = true;
    }
