    var con = OpenFB2Connection();
    var trans = con.BeginTransaction();
    var command = new OleDbCommand("INSERT INTO ... VALUES ...  RETURNING Id");
    cmd.Parameters.Add("Id", OleDbType.Integer).Direction = ParameterDirection.Output;
    
    var Id = (int)cmd.ExecuteNonQuery(); //Here is your Id
