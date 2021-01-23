    class Program     
    {     
        static void Main(string[] args)     
        {     
            var rep = new Repository();     
    
            dynamic data = rep.GetPerson();     
            Console.WriteLine(data.Name);  
    
            dynamic data2 = rep.GetPersonWrappedInAnonymousType();     
            Console.WriteLine(data2.Person.Name);     
        }     
    }
