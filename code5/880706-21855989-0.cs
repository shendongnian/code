    public bool CanExecuteButtonC(object a)
    {
       If (!string.IsNullOrEmpty(Field1) && !string.IsNullorEmpty(Field2))
        return true;
       return false;
    }
