    try
    {
        connection.Open();
        try
        {
    
            string strPatients = "     SELECT h.patientID, 
                                              p.pFirstName,
                                              p.pLastName  
                                         FROM MEDICALHISTORY h 
                                    LEFT JOIN PATIENT p ON p.patientID = h.patientID 
                                    LEFT JOIN ILLNESS i ON i.illnessid = h.illnessID";
            using (SqlCommand cmdPatient = new SqlCommand(strPatients, connection))
            {
                using (SqlDataReader rdr = cmdPatient.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int patientID = Convert.ToInt32(rdr["patientID"]);
                        string pFName = Convert.ToString(rdr["pFirstName"]);
                        string pSName = Convert.ToString(rdr["pLastName "]);
                        string pIllness =Convert.ToString(rdr["IllnessDesc"]);
                        
                        // Do stuff with data
                   }
               }
            }
        }
        finally
        {
            connection.Close();
        }    
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error");
    }
