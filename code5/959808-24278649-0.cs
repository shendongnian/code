    // Read content
    string content = File.ReadAllText(filename);
    // Separate procedures from each other
    // (you might have to use "ToUpper()" before)
    string[] procs = content.Split(new string[] { "CREATE PROCEDURE" }, StringSplitOptions.None);
    // Check if one of them contains the table name
    string table = "ucg2.userCompanyId";
    foreach (string proc in procs)
    {
        // If it does, print the first line (which holds the name of the stored procedure
        // (Using regex here might be necessary, depending on the source)
    	if (proc.Contains(table))
    	{
    		Console.WriteLine(proc.Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
    	}
    }
