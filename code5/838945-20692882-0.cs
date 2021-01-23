    namespace PetaPocoTest
    {
        public partial class Form1 : Form
        {
            PetaPoco.Database db = new PetaPoco.Database("PgConnection");
    
            IEnumerable<customers> allCustomers;
    
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                allCustomers = db.Query<customers>("SELECT * FROM customers");
                mGrid.DataSource = allCustomers .ToList();            
            }
    
            private void simpleButton1_Click(object sender, EventArgs e)
            {
                 foreach (var a in allCustomers)
                 {
                   db.Save("customers", "custumer_id", a);
                 }
            }
        }
    }
