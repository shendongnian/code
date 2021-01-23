    public List<Class1> Find(List<Class1> updated, List<Class1> existing, Func<Class1, bool> predicate)
    {
        foreach (Class1 gender in updated)
        {
            Class1 _gender = existing.FirstOrDefault(predicate); //predicate for quoted example will be o => o.GenderID == gender.GenderID
            if (_gender == null)
            {
                //do some stuff here like attach and add
            }
        }
        return existing;
    }
