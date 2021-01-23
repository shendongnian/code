    public static T ChangePersonTo<T>(IPerson person)
    where T : IPerson, new T()
    {
       return new T
       {
    	   Name = person.Name,
    	   Age = person.Age
       };
    }
