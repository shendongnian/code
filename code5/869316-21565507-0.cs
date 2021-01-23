    var builder = new StringBuilder("INSERT INTO MedicationLine (MedicationName, Quantity, Price) VALUES ");
    int i = 0;
    var parameters = new List<SqlParameter>();
    
    foreach (DataGridViewRow row in this.dataPrescription.Rows)
    {
        string cAppointment = txtAppointmentID.Text;
    
        if (cAppointment == "NO APPOINTMENT HAS BEEN MADE")
        {
            MessageBox.Show("Please make an appointment first at the Nurse counter", "WARNING");
            return;
        }
    
        string cMedication = row.Cells[0].Value.ToString();
        string cQuantity = row.Cells[1].Value.ToString();
    
        i++;
    
        string strConnectionString = ConfigurationManager.ConnectionStrings["HConnection"].ConnectionString;
        string strCalc = "SELECT medicationPrice FROM MEDICATION WHERE medicationName = @medicationName";
    
        using (SqlConnection connection = new SqlConnection(strConnectionString))
        {
            using (SqlCommand cmdCalc = new SqlCommand(strCalc, connection))
            {
                command.Parameters.Add(new SqlParameter("medicationName", cMedication);
                connection.Open();
    
                SqlDataReader readPrice = cmdCalc.ExecuteReader();
                
                if (readPrice.Read())
                {
                    string getPrice = readPrice["medicationPrice"].ToString();
                    double doublePrice = Convert.ToDouble(getPrice);
                    double doubleQuantity = Convert.ToDouble(cQuantity);
    
                    builder.AppendLine();
                    builder.Append("(";
                    builder.Append("@Name");
                    builder.Append(i);
                    builder.Append("@Qty");
                    builder.Append(i);
                    builder.Append("@Price");
                    builder.Append(i);
                    builder.Append("),";
    
                    parameters.Add(new SqlParameter("Name" + i.ToString(), medicationName);
                    parameters.Add(new SqlParameter("Qty" + i.ToString(), doubleQuantity);
                    parameters.Add(new SqlParameter("Price" + i.ToString(), doublePrice);
                }
    
                readPrice.Close();
                connection.Close();
            }
        }
    }
