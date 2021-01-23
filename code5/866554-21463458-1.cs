        public void LoadData(ref SqlDataReader sdr)
            {
        
                    while (sdr.Read())
                    {
                        txtProductCode1.Text = Convert.ToString(sdr["ProductCode"]);
                    }            
                    Activate();
            }  
