    int counter = 0;
    while(reader.Read())
    {
       ...
       ...
       if(GDR_EnumVoiePublique.ExecuteNonQuery() > 0)
       {
          counter++;
       }
    }
