    private void combGenerator(int currEl, int begVal)
    {
        for (int c = begVal; c <= currEl + totalCells - maxCells; c++)
        {
            manualResetEvent.WaitOne();
            // do stuff
        }
    }
