    using (SqlConnection cnn1 = getConnection(1))
    {
       //...Do whatever want to do
       using (SqlConnection cnn2 = getConnection(2))
       {
           //...Do whatever want to do
           using (SqlConnection cnn3 = getConnection(3))
           {
               //...Do whatever want to do
               cnn3.Close();
           }
           cnn2.Close();
       }
       cnn1.Close();
    }
    
    
    private SqlConnection getConnection(int connID)
    {
        switch(connID)
        {
            case 0:
                return new SqlConnection("first conn string");
                break;
            case 1:
                return new SqlConnection("first conn string");
                break;
            case 2:
                return new SqlConnection("first conn string");
                break;
        }
    
    }
