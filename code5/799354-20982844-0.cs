     public partial class Secured_pia : System.Web.UI.Page
        {
            String sConn = "Your connection string";
            private NpgsqlConnection conn;
            private NpgsqlDataAdapter da;
            private DataSet ds = new DataSet();
            private DataTable dt = new DataTable();
            private NpgsqlCommandBuilder cb;
    
            public Secured_pia ()
            {
                InitializeComponent();
            }
    //your form load code above goes here but you will have to do 
    //a global declaration like I did here instead of in the form load event like you have. 
    
    //update button implementation.  
    private void btnUpdate_Click(object sender, EventArgs e)
     {
        cb = new NpgsqlCommandBuilder(da);           
        da.Update(dt);
     }
