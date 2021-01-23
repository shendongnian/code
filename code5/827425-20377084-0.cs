    SqlCommand mainCMD = new SqlCommand( " INSERT INTO Country (name) VALUES (@parmCountry)", conn);
    // just to prime the parameter with proper data type string expectation
    mainCMD.Parameters.AddWithValue("@parmCountry", "test country");
    for (int i = 0; i < 5; i++)
    {
       // change ONLY the parameter, then execute it
       mainCMD.Parameters[0].Value = "Country" + i.ToString();
       mainCMD.ExecuteNonQuery();
    }
