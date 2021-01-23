    public T Value
    {
      get{return m_Value;}
      set
      {
        if(m_Value != value)
        {
          m_Value = value;
          OnPropertyChanged(()=>Value);
        }
      }
    }
