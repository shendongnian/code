    private ObservableCollection<Employer> employersField;
    public ObservableCollection<Employer> Employers
    {
    		get { return employersField; }
		set {
			employersField= value;
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs("Employers"));
			}
		}
    }
