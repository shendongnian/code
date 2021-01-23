    public class MyClass
    {
        string VarA;
        string VarB;
        string VarC;
    }
        
    public List<MyClass> GetResults()
    {
        using (SqlConnection conn = new SqlConnection("YourConnection"))
        {
            return conn.Select().ExecuteReader<MyClass>(conn, "YourStoredProcedure");
        }
    }
