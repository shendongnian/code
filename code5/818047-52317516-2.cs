        public void ChargingArraySelect()
        {
            int loop = 0;
            int registros = 0;
            OdbcConnection conn = WebApiConfig.conn();
            OdbcCommand query = conn.CreateCommand();
            query.CommandText = "select dataA, DataB, dataC, DataD FROM table  where dataA = 'xpto'";
            try
            {
                conn.Open();
                OdbcDataReader dr = query.ExecuteReader();
                //take the number the registers, to use into next step
                registros = dr.RecordsAffected;
                //calls an array to be populated
                Global.arrayTest = new string[registros, 4];
                while (dr.Read())
                {
                    if (loop < registros)
                    {
                        Global.arrayTest[i, 0] = Convert.ToString(dr["dataA"]);
                        Global.arrayTest[i, 1] = Convert.ToString(dr["dataB"]);
                        Global.arrayTest[i, 2] = Convert.ToString(dr["dataC"]);
                        Global.arrayTest[i, 3] = Convert.ToString(dr["dataD"]);
                    }
                    loop++;
                }
            }
		}
        //Declaration the Globais Array in Global Classs
        private static string[] uso_internoArray1;
        public static string[] arrayTest
        {
            get { return uso_internoArray1; }
            set { uso_internoArray1 = value; }
        }
