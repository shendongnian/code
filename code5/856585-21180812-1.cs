    public frmLeaveRequestConfirmation(DateTime SDate, DateTime EDate, string SDFH, string EDFH, bool RBHD)
    {
        InitializeComponent();
        lblStartDateInfo.Text = SDate.ToString("dddd, dd MMMM yyyy"); ;
        if (SDate == EDate)
        {
         //some codes are here                
        }
    }
