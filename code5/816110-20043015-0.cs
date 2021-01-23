    var name = cmd.ExecuteScalar();
    
    if (name != null)
    {
       position = name.ToString();
       Response.Write("User Registration successful");
    }
    else
    {
        Console.WriteLine("No Employee found.");
    }
