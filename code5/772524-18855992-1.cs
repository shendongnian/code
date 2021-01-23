    public partial class AddNews_AddNews : System.Web.UI.Page
        {    
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click1(object sender, EventArgs e)
            {
                using(var connection = this.GetConnection())
                {
                   using(var cmd = new SqlCommand())
                   {
                      cmd.CommandText = "INSERT INTO " + drbdlSection.SelectedItem + "(Title, Contect) VALUES (@param1, @param2)";
                      cmd.Parameters.AddWithValue("@param1", titleTextBox.Text);
                      cmd.Parameters.AddWithValue("@param2", CKEditor1.Text);
                      cmd.Connection.Open();
                      cmd.ExecuteNonQuery();
                   }
                }
            }
    
            protected SqlConnection GetConnection()
            {
                var connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=BrainStorms;User ID=sa;Password=xxx");
                return connection;
            }
    
        }
