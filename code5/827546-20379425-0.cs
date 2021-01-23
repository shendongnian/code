     public UserControl1()
            {
                InitializeComponent();                
                this.monthCalendar1.DateSelected += new DateRangeEventHandler(monthCalendar1_DateSelected);
            }
    
            public void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
            {
                OnSeChanged(e);
            }
    
            public event DateRangeEventHandler SeChanged;
    
            protected virtual void OnSeChanged(DateRangeEventArgs e)
            {
                if (SeChanged != null)
                {
                    SeChanged(this, e);
                }
            }
