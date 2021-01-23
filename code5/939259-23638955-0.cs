    //this is a Predicate<string> b/c it takes a string as input and outputs a boolean
    bool ExamplePredicate(string input)
    {
        return input == "something";
    }
    //function accepting an array of Predicate<string> as input
    bool Validate(Predicate<string>[] validators /*, other data input*/ )
    {
        //use the array of validators to process your data.
    }
    void Test()
    {
        //array of validators
        var validators = new Predicate<string>[]
        {
            aString => !string.IsNullOrEmpty(aString), // you can use lambda expressions
            ExamplePredicate               // or reference functions matching the predicate definitions
        }
        Validate(validators);
    }
