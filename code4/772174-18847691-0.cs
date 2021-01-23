    public class DBUtility
    {
    public SqlConnection cn;
     public void init()
    {
    //initialize cn here
    }
    
    public DataSet getdata(string query)
    {
    //execute query using cn
    }
    }
    
    public class DBUtility2 : DBUtility
    {
    public void init()
    {
    //initialize cn here
    }
    }
