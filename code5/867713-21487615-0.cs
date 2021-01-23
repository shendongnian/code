    for (int i = 0; i < dataPrescription.Rows.Count; i++)
            {
                string firstColumn = dataPrescription[0, dataPrescription.CurrentCell.RowIndex].Value.ToString();
                string strMedications = "SELECT medicationID FROM MEDICATION WHERE medicationName=   ('" + firstColumn + "')";
                SqlCommand cmdMedications = new SqlCommand(strMedications, connection);
                SqlDataReader dr = new SqlDataReader(); //Insert this line in your code
                SqlDataReader readMedications = cmdMedications.ExecuteReader();
