    public event DateRangeEventHandler DateChanged;
    public UserControl1() {
      InitializeComponent();
      monthCalendar1.DateChanged += monthCalendar1_DateChanged;
    }
    void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) {
      if (DateChanged != null) {
        DateChanged(this, e);
      }
    }
