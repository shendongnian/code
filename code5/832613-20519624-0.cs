    // Open your connection here
    SqlConnection con = new SqlConnection("Data Source=Abdullah-PC;Initial Catalog=SmartPharmacyDB;Integrated Security=True");
    con.Open();
    // The using statement declares that you want to use the SqlDataReader for a certain
    // block of code. Can be used because it implements IDisposable
    using(SqlDataReader DR = d.comboboxLoad(con)) {
        while (DR.Read())
        {          
            DrugNameCombo.Items.Add(DR["drugname"]);
        }
    }
    // When we reach here, the SqlDataReader will be disposed
    // Could do some more work here
    // Finally close the connection
    con.Close();
