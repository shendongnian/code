    public class MyPage : Page
    {
        private SqlConnection _conn;
    
        protected void Page_Load(object sender, EventArgs e){
            _conn = new SqlConnection(connectionString);
        }
    
        protected void btnInsert_Click(object sender, EventArgs e){
            using (var command = new SqlCommand(commandString, _conn)){
                command.ExecuteNonQuery();
            }
        }
    }
