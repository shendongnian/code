      string constring = @"Data Source=|DataDirectory|\LWADataBase.sdf";
                string Query = "select * from settingsTBL where Reference = 1; ";
                SqlCeConnection conDataBase = new SqlCeConnection(constring);
                SqlCeCommand cmdDataBase = new SqlCeCommand(Query, conDataBase);
                SqlCeDataReader myReader;
                
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    myReader.Read();
                    
                        string sCompany = myReader.GetString(myReader.GetOrdinal("Company Name"));
                        string sAddress1 = myReader.GetString(myReader.GetOrdinal("Address Line 1"));
                        string sAddress2 = myReader.GetString(myReader.GetOrdinal("Address Line 2"));
                        string sPost = myReader.GetString(myReader.GetOrdinal("Post Code"));
                        string sTelephone = myReader.GetString(myReader.GetOrdinal("Telephone Number"));
                        string sEmail = myReader.GetString(myReader.GetOrdinal("Email Address"));
                        string sRegistration = myReader.GetString(myReader.GetOrdinal("Registration Number"));
                        
           
                    
                   
            
           
            
           
            
            Paragraph lwa = new Paragraph(""+sCompany+ "\n " +sAddress1+ " " + sAddress2+"\n " +sPost+"\n Email Address: " + sEmail+ "\n Telephone: " +sTelephone+ "\n " +sRegistration+"" );
            
            lwa.Alignment = Element.ALIGN_LEFT;
            invoice.Add(lwa);
