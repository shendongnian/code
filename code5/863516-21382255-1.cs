    using (SqlCommand cmdMedications = new SqlCommand(strMedications, connection))
    {
        string strMedications = "SELECT medicationName FROM MEDICATION WHERE medicationType = @selectedMedication;
        command.Parameters.AddWithValue("selectedMedication", cboMedicationType.SelectedItem.ToString());
        connection.Open();
        using (SqlDataReader readMedications = cmdMedications.ExecuteReader())
        {
            while (readMedications.Read())
            {
                string medicationVar = readMedications["medicationName"].ToString();
                clbMedication.Items.Add(medicationVar, true);
            }
        }
        connection.Close();
    }
