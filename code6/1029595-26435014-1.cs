    private void HandleStatusChange(int newValue)
    {
        if (newValue == 1)
        {
           //Threaded so we don't hang the timer callback
           new Thread(() =>
           {
              uCard uc1 = new uCard(this);
              uc1.ShowDialog();
           }).Start();
        }
    }
    
