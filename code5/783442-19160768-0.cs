    using (SqlConnection connection = new SqlConnection(connString))
    {
        using (SqlCommand command = new SqlCommand("SELECT ID, contactName, jobTitle, currentAddress, workAddress, workPhone, cellPhone FROM ContactsInformations", connection))
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                DataTable dataSet = new DataTable();
                dataAdapter.Fill(dataSet);
                BindingSource bindingSrc = new BindingSource();
                bindingSrc.DataSource = dataSet;
                dataGridView1.DataSource = bindingSrc;
                dataAdapter.Update(dataSet);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                throw;
            }
        }
    }
