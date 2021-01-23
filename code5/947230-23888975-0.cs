    public class PersonDAL
        {
            public string ConString =
               @"Standard security Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccessFile.accdb; Persist Security Info=False;";
            OleDbConnection con;
            DataTable dt;
            public PersonDAL()
            {
                con = new OleDbConnection();
                dt = new DataTable();
            }
    
            public DataTable Read()
            {
                con.ConnectionString = ConString;
                if (ConnectionState.Closed == con.State)
                    con.Open();
                OleDbCommand cmd = new OleDbCommand("select * from Person", con);
                try
                {
                    OleDbDataReader rd = cmd.ExecuteReader();
                    dt.Load(rd);
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
            public DataTable Read(Int16 Id)
            {
                con.ConnectionString = ConString;
                if (ConnectionState.Closed == con.State)
                    con.Open();
                OleDbCommand cmd = new OleDbCommand("select * from Person where ID= " + Id + "", con);
                try
                {
                    OleDbDataReader rd = cmd.ExecuteReader();
                    dt.Load(rd);
                    return dt;
                }
                catch
                {
                    throw;
                }
            }
        }
