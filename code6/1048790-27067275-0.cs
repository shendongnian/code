    public void ConversionTest()
    {
        Personperson = new Person { FirstName = "Bob", LastName = "Smith" };
        IValidatable validatable = Validatable.AsValidatable(person);
        Person cast = (Person)validatable; // FAILS here with InvalidCastException
    }
