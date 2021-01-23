    
    OracleParameter p2 = new OracleParameter(":p_strings", OracleDbType.Varchar2, ParameterDirection.Output);
    p2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    p2.Size = 100; // allocate enough extra space to retrieve expected result
    // assign amount of space for each member of returning array
    p2.ArrayBindSize = Enumerable.Repeat(250, 100).ToArray(); 
    
    cmd.Parameters.Add(p2);
    cmd.ExecuteNonQuery();
    // And this is how you retrieve values
    OracleString[] oraStrings = (OracleString[])p2.Value;
    string[] myP2Values = new string[oraStrings.Length];
    for (int i = 0; i < oraNumbers.Length; i++)
        myP2Values[i] = oraStrings[i].Value;
