    public partial class Form1 : Form
    {
        Database db = new Database();
    
        public Form1()
        {
            InitializeComponent();
            //db.Test(); // Removed!
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            db.MdfConnectionString = ConfigurationManager.ConnectionStrings["MDFConnection"].ConnectionString;
            db.Test(); // Returns a value! :D
        }
    }
