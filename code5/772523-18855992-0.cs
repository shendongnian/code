    public partial class AddNews_AddNews : System.Web.UI.Page
        {
            protected SqlConnection _connection;
            protected SqlCommand _command;
            protected SqlDataAdapter _adp;
            protected System.Data.DataTable _tbl;
    
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click1(object sender, EventArgs e)
            {
                prepareConnection();
                _command.CommandText = "INSERT INTO " + drbdlSection.SelectedItem + "(Title, Contect) VALUES (@param1, @param2)";
                _command.Parameters.AddWithValue("@param1", titleTextBox.Text);
                _command.Parameters.AddWithValue("@param2", CKEditor1.Text);
                _command.Connection.Open();
                _command.ExecuteNonQuery();
                _command.Connection.Close(); 
                _command.Connection.Dispose();
                _command.Dispose();
            }
    
            protected void prepareConnection()
            {
                _connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=BrainStorms;User ID=sa;Password=xxx");
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
    
            }
    
        }
