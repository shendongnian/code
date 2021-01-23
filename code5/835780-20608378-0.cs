    private void ClickExecute(object parameter)
    {
        Contract.Requires<ArgumentNullException>((parameter as TypeA) != null, "typeA");
        Contract.Requires<ArgumentException>(toolsMenuItem.IsValid, "Not Valid");
    }
     
