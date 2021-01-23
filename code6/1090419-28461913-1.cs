    public Patient Patient
    {
        get { return (Patient)GetValue(PatientProperty); }
        set
        {
            SetValue(PatientProperty, value);
            OnPropertyChanged();
        }
    }
