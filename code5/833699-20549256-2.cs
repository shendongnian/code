    namespace login
    {
    public partial class _Default : Page
    {
        // decleration of tabels and dataadapters including my connection string for my MySQL databse
        DataSet ds = new DataSet();
        MySqlConnection cs = new MySqlConnection(@"SERVER= ********;username=******;password=******;Allow Zero Datetime=true; Initial Catalog = benoatsc_GreenFilm");
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        String totalDonations = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                    MySqlCommand SelectCommand = new MySqlCommand("select * from films.user where user_name=@username and password=@password;", cs);
                    MySqlDataReader myreader;
                    SelectCommand.Parameters.AddWithValue("@username",this.username.Text);
                    SelectCommand.Parameters.AddWithValue("@password",this.password.Text);
                    cs.Open();
                    myreader = SelectCommand.ExecuteReader();
                    int count = 0;
                    while (myreader.Read())
                    {
                        count = count + 1;
                    }
                    if (count == 1)
                    {
                        Response.Write(@"<script language='javascript'>alert('wow your in !!');</script>");
                    }
                    else if (count > 1)
                    {
                        Response.Write(@"<script language='javascript'>alert('duplicate');</script>");
                    }
                    else Response.Write(@"<script language='javascript'>alert('wrong password');</script>");
                    cs.Close();
                }
                catch (Exception ex)
                     {
                     Response.Write(@"<script language='javascript'>alert(ex.message);</script>");
                     }//end of catch block
            }//end of try block
        }//end of class 
    }//end of namespace
