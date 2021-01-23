    void MyMethod()  
    {  
        string fqdn = "host-6.domain.local";  
        string[] splitFqdn = fqdn.Split('.');  
        List<string> values = new List<string>();  
        values.add("host-1");  
        values.add("host-2.domain.local");  
        values.add("host-3.domain.local");  
        values.add("host-4");  
        values.add("host-5.other.local");  
        IEnumerable<string> queryResult = null;
        List<string> correctResult = null;
        for (int i = splitFqdn.Length; i > 0; i--)  
        {  
            queryResult =  
                from value in values  
                where value.StartsWith(  
                    string.Join(".", splitFqdn.Take(i)))  
                select value;
            correctResult = queryResult.ToList();
            Console.WriteLine(  
                "Inside for loop, take " + i + ": "  + queryResult.Count());  
        }  
        Console.WriteLine();  
        Console.WriteLine(  
            "Outside for loop queryresult: " + queryResult.Count());  
        Console.WriteLine(  
            "Outside for loop correctresult: " + correctResult.Count());  
    }
 
