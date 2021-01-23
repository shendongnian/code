    public Form3(DateTime chkindate)
    {
        InitializeComponent();
        ChkInDate = chkindate;
        CheckInTxt.Text = chkindate.ToString(); // add this line
    }
