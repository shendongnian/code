        string constring = @"Data Source=|DataDirectory|\LWADataBase.sdf";
            string Query = "select Reference from customersTBL ";
            SqlCeConnection conDataBase = new SqlCeConnection(constring);
            SqlCeCommand cmdDataBase = new SqlCeCommand(Query, conDataBase);
            SqlCeDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
    
                while (myReader.Read())
                {
                    comboRef.Items.Add(Convert.ToString(myReader.GetInt32(0)));
    
                    //string sRef = Convert.ToString(myReader.GetString(myReader.GetOrdinal("Reference")));
    
    //                comboRef.Items.Add(sRef);
                }
    
                //displays a system error message if a problem is found
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
