    const int ClicksRequired = 5;
    readonly TimeSpan ClickTimeSpan = new TimeSpan(0, 0, 10);
    Queue<DateTime> _clicks = new Queue<DateTime>();
    
    private void clickTarget_MouseUp(object sender, MouseEventArgs e)
    {
        var currentTime = DateTime.Now;
        _clicks.Enqueue(currentTime);
        
        if (_clicks.Count == ClicksRequired)
        {
            var firstTime = _clicks.Dequeue();
            if (currentTime - firstTime <= ClickTimeSpan)
            {
                MessageBox.Show("Hello World!");
                _clicks.Clear();
            }
        }
    }
