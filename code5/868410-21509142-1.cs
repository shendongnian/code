    try
    {
        connection.Open();
        try
        {
    
            var patientID = 0;
            string strPatients = "SELECT patientID FROM MEDICALHISTORY";
            using (SqlCommand cmdPatient = new SqlCommand(strPatients, connection))
            {
                using (SqlDataReader rdr = cmdPatient.ExecuteReader())
                {
                    rdr.Read();
                    patientID = Convert.ToInt32(rdr["patientID"]);
                }
            }
        
            string strMedicalPatients = "SELECT pFirstName, pLastName FROM PATIENT WHERE patientID= ('" + patientID + "')";
            using (SqlCommand cmdPatientHistory = new SqlCommand(strMedicalPatients, connection))
            {
                using (SqlDataReader readPatients = cmdPatientHistory.ExecuteReader())
                {
                    while (readPatients.Read())
                    {
                        ListViewItem allPatients = new ListViewItem(readPatients["pFirstName"].ToString());
                        allPatients.SubItems.Add(readPatients["pLastName"].ToString());
    
                        lsMedicalHistory.Items.Add(allPatients);
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
