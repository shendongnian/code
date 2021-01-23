    int numberOfCalls;
    bool result;
    foreach(DataRow dr in foundRows)
    {
        // Get value of Calls here
        result = Int32.TryParse(dr["Calls"], out numberOfCalls);
        // Optionally, you can check the result of the attempted try parse here
        // and do something if you wish
        if(result)
        {
            // Try parse to 32-bit integer worked
        }
        else
        {
            // Try parse to 32-bit integer failed
        }
    }
