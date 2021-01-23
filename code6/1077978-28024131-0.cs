    while (true)
    {
        if (!operationIsInProcess.WaitOne(timeout))
        {
            // timed out 
            break;
        }
        else
        {
            // Reset the signal.
            operationIsInProcess.Reset();
        }
    }
