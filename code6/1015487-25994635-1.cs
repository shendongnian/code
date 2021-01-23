    public bool IsExpanded
    {
        get
        {
            return m_IsExpanded;
        }
        set
        {
            if (Equals(m_IsExpanded, value))
            {
                return;
            }
    
            m_IsExpanded = value;
    
            NotifyPropertyChanged("IsExpanded");
        }
    }
