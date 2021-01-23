    private Person[] _people;
    public GroupOfPeople()
    {
        _people = new Person[0];
    }
    public void AddPerson(Person newPerson)
    {
        Person[] _More= new Person[_people.Length +1];
        _More[_people.Length] = newPerson;
        _people = _More;
    }
    public void DisplayAllPeople()
    {
        foreach (Person i in _people)
        {
            Console.WriteLine(i);
        }
    }
