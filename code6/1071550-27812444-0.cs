    // Invoke the background monitor
    int _5mins = 5 * 60 * 1000;
    System.Threading.Tasks.Task.Factory.StartNew(() => PeriodicallyClearList(foundKeywordsList, _5mins));
    // Method to clear the list
    void PeriodicallyClearList(List<string> toClear, int timeoutInMilliseconds)
    {
        while (true)
        {
            System.Threading.Thread.Sleep(timeoutInMilliseconds);
            toClear.Clear();
        }
    }
