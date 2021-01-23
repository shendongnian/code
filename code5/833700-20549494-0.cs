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
                    using (MySqlCommand SelectCommand = new MySqlCommand("select count(*) from films.user where user_name=@username AND password = @password", cs))
                    {
                        SelectCommand.Parameters.AddWithValue("@username", username.Text);
                        SelectCommand.Parameters.AddWithValue("@password", password.Text);
                        cs.Open();
                        int count = (int)SelectCommand.ExecuteScalar();
                        if (count == 1)
                        {
                            Response.Write(@"<script language='javascript'>alert('wow your in !!');</script>");
                        }
                        else if (count > 1)
                        {
                            Response.Write(@"<script language='javascript'>alert('duplicate');</script>");
                        }
    
                        else Response.Write(@"<script language='javascript'>alert('wrong password');</script>");
                    }
                }
    
                catch (Exception ex)
                {
                    Response.Write(@"<script language='javascript'>alert(ex.message);</script>");
                }
    
            }
        }
    }
