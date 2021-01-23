    private void ClickExecute(object parameter)
    {
        Contract.Requires<ArgumentException>(parameter is TypeA);
        Contract.Requires<ArgumentException>(((typeA)parameter).IsValid);
    }
     
