    using(OracleConnection connection = new OracleConnection("yourConnectionString"))
    using (
        OracleCommand command =
            new OracleCommand(@"INSERT INTO my_table (MODULE, USERNAME, COMPUTER, DATE,NAME, EMAIL ) 
               values (:myModule, :mmouse,:mickey007, :myDateTime,:myothercol, :myEmail", connection))
    {
        //add parameters
        command.Parameters.Add(":myModule", OracleDbType.Varchar2).Value = "myModule";
        command.Parameters.Add(":myDateTime", OracleDbType.Date).Value = DateTime.Now; // like this
        //add other parameters similarly. 
        connection.Open();
        //execute command
    }
