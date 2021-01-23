    public static void SetValues(List<ClassB> listOfB, List<ClassC> listOfC)
    {
        var bAndC = from b in listOfB
                    from bc in b.List2
                    join c in listOfC
                    on bc.ID equals c.ID
                    select new{ bc, c };
        foreach(var both in bAndC)
        {
            both.bc.SomeProperty = both.c.SomeProperty;
        }
    }
