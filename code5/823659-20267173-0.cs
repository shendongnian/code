    //property selector
    Func<Person, Boolean> propertySelector = person => person.FirstNameIsActive;
    //your predicate
    Func<Person, Boolean> predicate = person => propertySelector(person) == true;
    //new person with true, false properties.
    Person p = new Person() {FirstNameIsActive = true,SecondNameIsActive = false};
    Console.WriteLine(predicate(p).ToString()); //prints true
    //change the property selector
    propertySelector = person => person.SecondNameIsActive;
    //now the predicate uses the new property selector
    Console.WriteLine(predicate(p).ToString()); //prints false
