    public Member SelectedMember // Implement the INotifyPropertyChanged Interface here!!
    {
        get { return selectedMember; }
        set
        {
            if (selectedMember != value)
            {
                selectedMember = value;
                NotifyPropertyChanged("SelectedMember");
            }
        }
    }
