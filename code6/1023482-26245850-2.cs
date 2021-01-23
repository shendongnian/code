    if(dr.HasRows)
    {
        bool IsFirst = true;
        while(dr.Read())
        {
           if(IsFirst)
           {
               ...
              IsFirst = false;
           }
        }
    }
