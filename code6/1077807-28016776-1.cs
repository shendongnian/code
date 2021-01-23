    public void UpdateTextBoxThread()
    {
        for(int loop = 0; loop < 1000; loop++)
        {
            //Invoke the delegate within the UI thread context 
            Invoke(new UpdateTextBoxDelegate(InvokeUpdateTextBox), loop);
        }
    }
