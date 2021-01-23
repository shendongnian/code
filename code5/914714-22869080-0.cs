    // This line declares a variable named Values and sets its value to a new array of strings.
    // However, this new array is never used because the loop overwrites Values with a new array
    // before doing anything else with it.
    string[] Values = new string[3];                                 
    foreach (string line1 in lines)                 
    {                     
        Values = line1.Split(';');        
        // At this point in the code, whatever was previously stored in Values has been
        // tossed on the garbage heap, and Values now contains a brand new array containing
        // the results of splitting line1 on semicolons.
        // That means that it is no longer safe to assume how many elements the Values array has.
        // For example, if line1 is blank (which often happens at the end of a text file), then
        // Values will be an empty array, and trying to get anything out of it will throw an
        // exception                                   
        string query = "INSERT INTO demooo VALUES ('" + Values[0] + "','" + Values[1] + "','" + Values[2] + "')";                     
        cmd = new SqlCommand(query,con);                     
        cmd.ExecuteNonQuery();                  
    } 
