    public string MySliderValueProperty
    {
        get { return m_SliderValue; }
        set
        {
            if (m_SliderValue == value)
                return;
            // here we have an updated value
            m_SliderValue = value;
            RaisePropertyChanged(() => MySliderValueProperty);
        }
    }
