    public partial class frmMyForm
    {
        private My_Entities db;
        public frmMyForm()
        {
            InitializeComponent();
        }
     	private void SomeControl_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
	    db.Dispose();
            db = new My_Entities();
	    ...  More Code using db ...
	}
    
