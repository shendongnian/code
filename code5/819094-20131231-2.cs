    public partial class Doctor : Form
    {
    
        public Doctor()
        {
           InitializeComponent();
           // Remove all the code used to initialize the global objects here
        }
    
        private void Doctor_Load(object sender, EventArgs e)
        {
           // Open the connection just when needed, 
           // Initialize the adapter and fill the grid
           using(SqlCeConnection con = new SqlCeConnection(.....))
           {
                DataTable t = new DataTable();
                SqlCeDataAdapter a = new SqlCeDataAdapter("SELECT * FROM Doctor", con);
                a.Fill(t);
                DoctorView.DataSource = t;
           }
        }
    
        private void Save_Click(object sender, EventArgs e)
        {
           using(SqlCeConnection con = new SqlCeConnection(.....))
           {
                
                // Prepare again the adapter with a valid select command
                SqlCeDataAdapter a = new SqlCeDataAdapter("SELECT * FROM Doctor", con);
                // Force the building of the internal command objects of the adapter
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(a);
                
                // Recover the datatable from the datasource of the grid            
                DataTable t = DoctorView.DataSource as DataTable;
   
                // Update the table with DataRows changed, deleted or inserted
                a.Update(t);
           }
        }
    }
     
