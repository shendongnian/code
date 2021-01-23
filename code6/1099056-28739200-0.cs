    private bool longOperationRunning;
    private void async ProcessClick(object o, EventArgs e){
        if (longOperationRunning)
            return;
        longOperationRunning = true;
        await LongOperation()
        longOperationRunning = false;
    }
