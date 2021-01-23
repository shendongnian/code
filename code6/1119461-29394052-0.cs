    public static int subsumer(string id,int acc,SqlConnection connection) 
    {
        SqlCommand cercas = new SqlCommand("select * from common_relation where id_source ='" + id + "' AND type='@' ", connection);
        SqlDataReader leggsyn = null;
        leggsyn = cercas.ExecuteReader();
    
        int f = 0;
        while (leggsyn.Read()) 
        {
            f=  subsumer(leggsyn["id_target"].ToString(),acc + 1,connection);
            if (acc <= f) 
            { 
                acc = f; 
            }  
        }
    
         //siamo arrivati alla fine
        return acc;
    }
