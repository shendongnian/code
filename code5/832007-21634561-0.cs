    public class datos 
        {
            public string column1 { get; set; }
            public string column2 { get; set; }
        }     
       public static string  myConnection { get { return       @"Server=.\SQLExpress;AttachDbFilename=C:\Users\base.mdf;Trusted_Connection=Yes;"; } }
    public List<datos> example (){   
    List<datos> lista = new List<datos>();
            datos dat = new datos();
            SqlCommand adaptador = new SqlCommand("Select * from Yourtable", myConnection);
             myConnection.Open();
             SqlDataReader x =  adaptador.ExecuteReader();
            
             while (x.Read()) 
             {
                dat.column1 = x["column1fromyoutable"].ToString();
                dat.column2 = x["column2fromyourtable"].ToString();
                lista.Add(dat);
             }
             myConnection.Close();
            return lista;
        }
