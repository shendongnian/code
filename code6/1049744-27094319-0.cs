    DataTable mDataTable = new DataTable(); //class field
    
    public Constructor()
    {
        InitializeComponent();
        userDataGrid.ItemsSource = mDataTable .mDataTable;
    }    
    void PullData()
    {
        mDataTable.Clear();
        
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            sda = new SqlDataAdapter("SELECT TeacherID, ClassName, ClassID FROM CLASS", conn);
            sda.Fill(mDataTable );
        }
    }
