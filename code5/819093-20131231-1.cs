    public partial class Doctor : Form
    {
        // Leave just the adapter as global variable
        SqlCeDataAdapter a;
    
        public Doctor()
        {
           InitializeComponent();
           // Remove all the code used to initialize the global objects here
        }
    
        private void Doctor_Load(object sender, EventArgs e)
        {
           // Open the connection just when needed, 
           // Initialize the adapter here and call the CommandBuider constructor to force
           // the initialization of the internal adapter commands
           using(SqlCeConnection con = new SqlCeConnection(.....))
           {
                DataTable t = new DataTable();
                a = new SqlCeDataAdapter("SELECT * FROM Doctor", con);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(a);
                a.Fill(t);
                DoctorView.DataSource = t;
           }
        }
    
        private void Save_Click(object sender, EventArgs e)
        {
            // Recover the datatable from the datasource of the grid            
            DataTable t = DoctorView.DataSource as DataTable;
            a.Update(t);
        }
    }
     
