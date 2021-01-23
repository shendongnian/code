    {
        // connection string!
        SqlConnection myConn = new SqlConnection("Server=localhost\\SQLEXPRESS;Integrated security=SSPI;database=Mynewdatabase;");
       
        try
        {
            myConn.Open();
            Console.WriteLine(myConn );
        }
        catch (System.Exception)
        {
           // some exception
        }
        finally
        {
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
            myConn.Dispose();
        }
    }
