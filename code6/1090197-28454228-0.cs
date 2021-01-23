    public void DoSomething(IEnumerable<SupremeBeing> peopleIn)
    {
        this.DoSomething(peopleIn.Cast<Person>());
        // do SupremeBeing specific stuff
    }
