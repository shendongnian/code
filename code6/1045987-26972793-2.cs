    private async void OnButtonStartClick(object sender, EventArgs e)
    {
        try
        {
            // Await will allow the UI to keep responsive
            // Furthermore it will automatically return to the UI SynchronizationContext when done, so updating a label
            // has not to be dispatched.
            _LabelResult = await Task.Factory.StartNew(
                () => PerformLongRunningOperation(_ctSource.Token), _ctSource.Token);
        }
        catch (TaskCanceledException ex)
        {
            MessageBox.Show("Calculation has been canceled.");
        }
    }   
