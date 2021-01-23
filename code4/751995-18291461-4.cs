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
                if (t.IsCompleted)
                    MessageBox.Show("Task is done!");
                else
                    MessageBox.Show("Task is caceled or faulted!");
                _pendingTask = null;
            });
        }
    }
