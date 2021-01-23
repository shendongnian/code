    public partial class frmMyForm
    {
        private My_Entities entity;
        public frmMyForm()
        {
            InitializeComponent();
        }
     	private void SomeControl_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
	        db.Dispose();
            entity = new My_Entities();
            //more code using entity ...
	}
    
