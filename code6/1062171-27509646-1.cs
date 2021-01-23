    public static T ChangePersonTo<T>(IPerson person)
    where T : IPeson, new T()
    {
       return new T
       {
    	   Name = person.Name,
    	   Age = person.Age
       };
    }
