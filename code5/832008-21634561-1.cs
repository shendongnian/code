    //this is my class  of data or my entity 
    public class datos 
        {
            public string column1 { get; set; }
            public string column2 { get; set; }
        }     
       
       //create a string with the connections parameter
       public static string  myConnection { get { return       @"Server=.\SQLExpress;AttachDbFilename=C:\Users\base.mdf;Trusted_Connection=Yes;"; } }
        //Create a method  of type List<datos> to return a list of datos
    public List<datos> example (){   
    List<datos> lista = new List<datos>();
          //declare and initialize my entity of type datos
            datos dat = new datos();
            //create a new command to do a query to my database
            SqlCommand adaptador = new SqlCommand("Select * from Yourtable", myConnection);
             //open my connection 
             myConnection.Open();
            // execute my command
             SqlDataReader x =  adaptador.ExecuteReader();
            //now i read the data that i get from my command and add data to my list
             while (x.Read()) 
             {
                dat.column1 = x["column1fromyoutable"].ToString();
                dat.column2 = x["column2fromyourtable"].ToString();
                lista.Add(dat);
             }
            // close connection
             myConnection.Close();
            //return list of data
            return lista;
        }
