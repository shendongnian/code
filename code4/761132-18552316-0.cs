    public static List<Person> ML = new List<Person>();
    public static void DeleteMember(string name)
    {        
        var deleteMe = ML.Find(p => p.Name == name);
        if (deleteMe == null)
        {
            Console.WriteLine(name + " had not been added before.");
        }
        else
        {
            ML.Remove(deleteMe);
        }
    }
