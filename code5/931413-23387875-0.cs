    private DateTime _selectedDate;
    public DateTime SelectedDate
    {
        get { return _selectedDate; }
        set
        {
            if (_selectedDate != value)
            {
                _selectedDate = value;
                GetAppointments(_selectedDate);
                NotifyPropertyChanged("SelectedDate");
            }
        }
    }
    public ObservableCollection<SCSMAppointment> Appointments { get; private set; }
    public AppointmentOverviewViewModel()
    {
        Appointments = new ObservableCollection<SCSMAppointment>();
        SelectedDate = DateTime.Today;
    }
    private void GetAppointments(datetime selectedDate)
    {
        Appointments.Clear();
        DateTime firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        int countDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        CalendarFolder calendar = CalendarFolder.Bind(service, WellKnownFolderName.Calendar, ps);
        CalendarView cView = new CalendarView(firstDay, firstDay.AddDays(countDays));
        FindItemsResults<Appointment> appointments = calendar.FindAppointments(cView);
        foreach (Appointment a in appointments)
        {
            Appointments.Add(scsmapp);
        }
    }
