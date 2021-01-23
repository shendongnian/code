    List<MyClass> MyClasses = new List<MyClass>();
    
    String strSQL = "select * from Table01";
    SqlCommand cmd = new SqlCommand { Connection = Cn, CommandText = strSQL };
    try
    {
        SqlDataReader = sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            MyClasses.Add(new MyClass(sdr.GetValue(0));
        }
        sdr.close();       
    }
    catch (Exception Ex) {}
    finally 
    {
        Cn.Close();
    }
