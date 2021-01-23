    public ObservableCollection<TabItemViewModel> TabItems
    {
        get
        {
            return m_SuspendTabItems;
        }
        private set
        {
            if (Equals(m_SuspendTabItems, value))
            {
                return;
            }
            m_SuspendTabItems = value;
            NotifyPropertyChanged(s_SuspendTabItems);
        }
    }
