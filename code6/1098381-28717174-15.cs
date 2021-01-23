    public static class Repository
    {
        public static List<object> Whatever(string prpClass)
        {
            switch (prpClass)
            {
                case "SomeClass":
                    return new List<SomeClass>() 
                    {
                       new SomeClass{Property = "somestring"},
                       new SomeClass{Property = "someOtherString"}
                    }.Cast<object>().ToList();
                default:
                    return null;
                   
            }
        }
    }
