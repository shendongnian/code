     try
        {
            string strMedicalPatients = "SELECT pFirstName, pLastName FROM PATIENT WHERE patientID in (select patientid from MedicalHistory)";
            SqlCommand cmdPatientHistory = new SqlCommand(strMedicalPatients, connection);
            connection.Open();
            SqlDataReader readPatients = cmdPatientHistory.ExecuteReader();
            while (readPatients.Read())
            {
                ListViewItem allPatients = new ListViewItem(readPatients["pFirstName"].ToString());
                allPatients.SubItems.Add(readPatients["pLastName"].ToString());
                lsMedicalHistory.Items.Add(allPatients);
            }
            readPatients.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error");
        }
        finally
        {
            connection.Close();
        }
