    public static List<SomeClass> SomeMethod(this IEnumerable<SomeClass> list, int id)
    {       
        List<SomeClass> result = new List<SomeClass> ();
        foreach (SomeClass something in list)
        {
            if(something.SomeProperty.SomeList.Contains(id))
            {
                result.Add (something);
            }
        }
        return result;
    }
