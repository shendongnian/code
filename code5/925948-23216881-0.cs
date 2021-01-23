    object s = sql.ExecuteScalar();
    if (s != null)
    {
        Console.WriteLine("Query returned value.");
    }
    else
    {
        Console.WriteLine("Query returned nothing.");
    }
