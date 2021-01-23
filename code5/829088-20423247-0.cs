    public bClass ItemSourceUI 
    {
        get { return (bClass)GetValue(ItemSourceUIProperty ); }
        set
        {
            SetValue(ItemSourceUIProperty , value);
            DataContext = value;
        }
    }
