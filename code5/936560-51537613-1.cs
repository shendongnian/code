    public partial class _Default : Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\rinka.sai\\Desktop\\WebApplication1\\App_Data\\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(TextBox1.Text,conn);
            SqlDataReader sdr = cmd.ExecuteReader() ;
            GridView1.DataSource = sdr;
            GridView1.DataBind();
            sdr.Close();
            conn.Close();
        }
    }
