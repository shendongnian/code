    OleDbConnection connection = new OleDbConnection("");
    string query = "INSERT INTO myTable (a,b,c) Values(@a, @b @c)";
    OleDbParameter param = new OleDbParameter("a", "Hi man");
    param.DbType = ...
    OleDbCommand command = new OleDbCommand(query);
    command.CommandType = System.Data.CommandType.Text;
    int result = command.ExecuteNonQuery();
 
