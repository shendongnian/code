    MyClass logic = new MyClass();
    private void SomeFunction
    {       
        logic.UpdateProgress += UpdateProgressBar;
    }
    
    private void UpdateProgressBar(int newProgress)
    {
        progressBar1.BeginInvoke(new Action(() =>
        {
           progressBar1.Value = newProgress;
        }));
    }
