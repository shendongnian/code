    // Create the command outside the loop defining the 5 parameters required
    SqlCommand SqlString4 = new SqlCommand(@"Update quex set docudisp = 70 
        where docudisp = 60 and admindisp in (40,43,91) 
        and barcode in (@b1, @b2, @b3, @b4, @b5)", con);
    // Create the five parameters with a dummy integer 
    SqlString4.Parameters.AddWithValue("@b1", 0);
    SqlString4.Parameters.AddWithValue("@b2", 0);
    SqlString4.Parameters.AddWithValue("@b3", 0);
    SqlString4.Parameters.AddWithValue("@b4", 0);
    SqlString4.Parameters.AddWithValue("@b5", 0);
    con.Open();
 
    // Increment the loop with i+=5 because it is not clear 
    // if you have more that 5 items in the myCollection array
    for (i = 0; i < totalbarcodes; i+=5)
    {
        SqlString4.Parameters["@b1"].Value = myCollection[i]);
        SqlString4.Parameters["@b2"].Value = myCollection[i+1]);
        SqlString4.Parameters["@b3"].Value = myCollection[i+2]);
        SqlString4.Parameters["@b4"].Value = myCollection[i+3]);
        SqlString4.Parameters["@b5"].Value = myCollection[i+4]);
        
        try
        {
             SqlString4.ExecuteNonQuery();
        }
        catch (Exception ex)
        { 
            MessageBox.Show(ex.Message); 
        }
    }
    con.Close();
