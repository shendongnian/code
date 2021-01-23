    private void buttonSomething_Click(object sender, EventArgs eventArgs)
    {
        OnMethodCompleted += (s, e) =>
        {
            MessageBox.Show("...");
        };
        Thread thread = new Thread(OnMethod);
        thread.Start();
    }
    
    private void OnMethod()
    {
        // Some long running operation here..
        OnMethodCompleted(this, EventArgs.Empty);
    }
    
    private static event EventHandler OnMethodCompleted = delegate { };
