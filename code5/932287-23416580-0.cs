    string name = txtUsername.Text;       
    NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=db;User Id=postgres;Password=postgres;"); 
    conn.Open();
    string sql = "SELECT COUNT(*) FROM tbl_employee WHERE username = @val1";
    NpgsqlCommand command = new NpgsqlCommand(sql, conn);  
    command.Parameters.AddWithValue("@val1", name);
    var result = command.ExecuteScalar();
    int i = Convert.ToInt32(result);
    if (i != 0)
    {
        FormsAuthentication.RedirectFromLoginPage(name, Persist.Checked);
    }
    else
    {
        lblMessage.Text = "Invalid username or password";
     }
