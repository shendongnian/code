    lock (_myLockObject)
    {
        if (payment.Status == ProcessingStatus.NotProcessed)
        {
            // update the status and start processing
        }
        else
        {
            // DO NOT PROCESS and display appropriate message to user
        }
    }
