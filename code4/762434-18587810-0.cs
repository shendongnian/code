    async Task<bool> WaitForItToWork()
    {
        bool succeeded = false;
        while (!succeeded)
        {
            // do work
            succeeded = outcome; // if it worked, make as succeeded, else retry
            await Task.Delay(1000); // arbitrary delay
        }
        return succeeded;
    }
