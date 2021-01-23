    private void ComboTransfer()
    {
        DataTable dt = new DataTable();
        string sql = "SELECT [Department] FROM [employeeTable]";
        using(SqlCommand cmd = new SqlCommand(sql, con))
        using(SqlDataReader dr = cmd.ExecuteReader())
        {
            dt.Load(dr);
        }
        comboBox1.DataSource = dt;
        Department_wise_Employee_Details dep = 
                     new Department_wise_Employee_Details(dt);
    }
    ....
    public partial class Department_wise_Employee_Details : Form
    {
        ....
        public Department_wise_Employee_Details(DataTable dt)
        {
            InitializeComponent();
            this.comboBox1.DataSource = dt;
        }
        ....
    }
