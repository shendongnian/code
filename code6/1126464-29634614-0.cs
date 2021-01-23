    try
    {
        using (var q = new PlQuery("get(sam,age(26))."))
        {
            if (q.Solutions == null) // Not sure if this is possible?
            {
                Console.WriteLine("Query did not run successfully.");
            }
            else
            {
                Console.WriteLine("Query returned {0} items.", q.Solutions.Count());
            }               
        }
    }
    catch (PlException ex)
    {
        Console.WriteLine("Exception handled: " + ex.Message);
    }
 
    Console.ReadLine();
