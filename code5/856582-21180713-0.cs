    public event EventHandler SomethingHappened;
    public frmLeaveRequestConfirmation(DateTime startDate, DateTime endDate, 
                                       int startDayIndex, int endDayIndex, 
                                       bool isHalfDayStart)
    {
        InitializeComponent();
        lblStartDateInfo.Text = startDate.ToString("dddd, dd MMMM yyyy");
        if (startDate == endDate)
        {
           // some codes are here
        }
    }
    // When something happened (e.g. user clicked a button)
    private void SomeButton_Click(object sender, EventArgs e)
    {
        if (SomethingHappened != null)
           SomethingHappened(this, EventArgs.Empty);
    }
