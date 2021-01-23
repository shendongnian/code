    public ICommand PrintText
            {
                get
                {
                    if (_printText == null)
                    {
                        _printText = new RelayCommand(p => PrintText(p as Control), p => CanPrintText(p as Control));
                    }
    
                    return _printText;
                }
            }
            protected abstract void PrintText(Control control); //Where you instantiate what it should do in a child class
    
            protected virtual bool CanPrintText(Control control)
            {
                return true;
            }
