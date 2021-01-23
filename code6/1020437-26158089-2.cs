    string path = @"D:\testfile.txt";
    System.IO.FileStream myStream = new System.IO.FileStream(@path, FileMode.Open);
    
    BinaryReader binaryReader = new BinaryReader(myStream);
    byte[] data = binaryReader.ReadBytes((int)myStream.Length); //read the stream into byte
    String sql =  "INSERT INTO testblob (testid, testblob) VALUES (100, :blobtodb)";       
    
    OracleCommand cmd = new OracleCommand();
    cmd.CommandText = sql; // Set the sql-command
    cmd.Connection = con; //con is an OracleConnection, create it before
    OracleParameter param = cmd.Parameters.Add("blobtodb", OracleDbType.Blob); //Add the parameter for the blobcolumn
    param.Direction = ParameterDirection.Input; 
    param.Value = data; //Asign the Byte Array to the parameter
    cmd.ExecuteNonQuery(); //You are done!
