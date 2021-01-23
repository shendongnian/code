    MyClass logic = new MyClass();
    logic.UpdateProgress += UpdateProgressBar;
    
    private void UpdateProgressBar(int newProgress)
    {
        Dispatcher.BeginInvoke(new Action(() =>
        {
           progressBar1.Value = newProgress;
        }));
    }
