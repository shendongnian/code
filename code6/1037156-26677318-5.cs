    public static int GetInt(string[] a)
    {
        int i = 0;
        try
        {
            foreach (string s in a)
               int.TryParse(s, out i);
        }     
        catch (System.Exception ex)
        {            
            Console.WriteLine("Error - could not return int" + ex.Message);
        }
        return i;
    }
