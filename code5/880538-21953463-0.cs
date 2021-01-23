    namespace PetaPocoTest
    {
        public partial class Form1 : Form
        {
            PetaPoco.Database db = new PetaPoco.Database("PgConnection");
            Dictionary<string, int> modRows = new Dictionary<string, int>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                bindingSource = db.Fetch<customers>("SELECT * FROM customers");
                mGrid.DataSource = bindingSource;            
            }
    
            private void saveButton_Click(object sender, EventArgs e)
            {
               db.BeginTransaction();
   
                   foreach (customers c in bindingSource)
                   {
                       if (modRows.ContainsKey(c.id.ToString()))
                       {
                           db.Save("customers", "id", c);
                       }
                   }
  
               db.CompleteTransaction();
            }
            private void mGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                int recId = ((customers)bindingSource.Current).id;
 
                if (!modRows.ContainsKey(recId.ToString()))
                {
                   modRows.Add(recId.ToString(), recId);
                }
            }
        }
    }
