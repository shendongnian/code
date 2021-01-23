       public void ChargingArraySelect()
        {
            int loopings = 0;
            int registros = 0;
            OdbcConnection conn = WebApiConfig.conn();
            OdbcCommand query = conn.CreateCommand();
            OdbcCommand query2 = conn.CreateCommand();
            query.CommandText = "select dataA, DataB, dataC, DataD FROM table  where dataA = 'xpto'";
            query2.CommandText = "select count(*) as REGISTROS FROM table  where dataA = 'xpto'";
            try
            {
                conn.Open();
                OdbcDataReader dr = query.ExecuteReader();
                OdbcDataReader dr2 = query2.ExecuteReader();
                while (dr2.Read())
                {
                    registros = Convert.ToInt32(dr2["REGISTROS"]);
                }
                //array com os dados resumidos da nota fiscal
                Global.arrayItensNotUpdi = new string[registros, 4];
                while (dr.Read())
                {
                    if (loopings < registros)
                    {
                        for (int i = 0; i < registros; i++)
                        {
                            Global.arrayItensNotUpdi[i, 0] = Convert.ToString(dr["dataA"]);
                            Global.arrayItensNotUpdi[i, 1] = Convert.ToString(dr["dataB"]);
                            Global.arrayItensNotUpdi[i, 2] = Convert.ToString(dr["dataC"]);
                            Global.arrayItensNotUpdi[i, 3] = Convert.ToString(dr["dataD"]);
                            loopings++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.codErro = 4;
                Global.retorno = ("Error:" + "COD: 4 " + " error in process - Detail: " + Convert.ToString(ex));
            }
            finally
            {
                conn.Close();
            }
        }
