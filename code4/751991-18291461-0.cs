    Task _pendingTask = null;
    
    void button_click()
    {
        if ( _pendingTask != null)
        {
            MessageBox.Show("Still working!");
        }
        else
        {
            _pendingTask = ProcessSearchAsync();
            _pendingTask.ContinueWith((t) =>
            {
                MessageBox.Show("Task is done!");
                _pendingTask = null;
            });
        }
    }
