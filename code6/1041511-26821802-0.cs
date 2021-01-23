    public static Dictionary<CommendTypes, string> dictioneary = new Dictionary<CommendTypes, string>
    {
        {CommendTypes.AddObserver,"Insert into ShowTableObserver(ID_Ob,Lat,Long,Azimuth)"
                                  +"values(?,?,?,?)"},
        {CommendTypes.AzimuthLongLatFromOB,"SELECT ID_Observer,Longitude,Latitude,Azimuth " 
                                  +"FROM Observer Where  ID_Observer = ?"}
    };
    public void InsertToDB(string sql, List<OleDbParameter> parameters)
    {
        int insert = 0;
        try
        {
            if (con.State.ToString()== "Open")
            {
                using(cmd = new OleDbCommand());
                {
                     cmd.Connection = con;
                     cmd.CommandText = sql;
                     cmd.Parameters.AddRange(parameters.ToArray());
                     insert = cmd.ExecuteNonQuery(); 
                }
                ........
           }
        }
        ......
    }
