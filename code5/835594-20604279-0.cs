    m_argumentUpDown.ValueChanged += new RoutedPropertyChangedEventHandler<object>(ArgumentChanged);
    //or you can change above line to following for brevity. ReSharper always suggesting me to do this
    //m_argumentUpDown.ValueChanged += ArgumentChanged;
    
    void ArgumentChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
    	//you need to cast New and Old value to int since both are of type object now
    	int newVal = (int)e.NewValue;
    	int oldVal = (int)e.OldValue;
    }
