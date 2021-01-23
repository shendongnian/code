    private void ProcessInnerTask(Task task)
    {
        // If the inner task is null, the proxy should be canceled.
        if (task == null)
        {
            TrySetCanceled(default(CancellationToken));
            _state = STATE_DONE; // ... and record that we are done
        }
        
        // ...
    }
