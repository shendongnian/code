    public void DoSomething(IEnumerable<SupremeBeing> peopleIn)
    {
        this.DoSomethingWithPersons(peopleIn);
    }
    public void DoSomething(IEnumerable<Person> peopleIn)
    {
        this.DoSomethingWithPersons(peopleIn);
    }
    private void DoSomethingWithPersons(IEnumerable<Person> peopleIn)
    {
        // do stuff
    }
