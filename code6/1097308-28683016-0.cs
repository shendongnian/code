    public Form1()
    {
       InitializeComponent();
       // I assume UserControl1 was created by this point
       userControl1.OnDataSorted = DataSorted;
    }
    
    // This will be called when the user wants to sort the data
    private void DataSorted(UserControl1 sender, EventArgs e)
    {
       // Change buttons around and fill in some data on user control 2 and 3
    }
