    private MyItem m_MySelectedItem;
    public MyItem MySelectedItem
    {
        get
        {
            return m_MySelectedItem;
        }
        set
        {
           m_MySelectedItem = value;
           NotifyPropertyChanged("MySelectedItem");
        }
    }
