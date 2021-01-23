    [SpecialName]
    public static T op_increment(Person<T> p)
    {
        return new T { Age = p.Age + 1 };   
    }
