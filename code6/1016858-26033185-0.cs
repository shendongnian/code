    private DelegateCommand<string> _leftCtrlKeyPressed;
    public ICommand LeftCtrlKeyPressed
    {
        get
        {
            if (_leftCtrlKeyPressed == null)
            {
                _leftCtrlKeyPressed = new DelegateCommand<string>(CtrlKeyDetected);
            }
            return _leftCtrlKeyPressed;  
        }
        set { }
    }
     public void CtrlKeyDetected(string parameter)
     {
         Console.WriteLine("Test=====>>" + parameter);
     }
