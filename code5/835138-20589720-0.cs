    // declaration of a normal example array
    string[] myArray = new string[] { "StackOverflow", "SuperUser", "MetaStackOverflow" };
    // declaration of a new ReadOnlyCollection whose elements are of type string
    // the string array is passed through the constructor
    // that's is where our array is passed into its new casing
    // as a matter of fact, the ReadOnlyCollection is a wrapper for ordinary collection classes such as arrays
    ReadOnlyCollection<string> myReadOnlyCollection = new ReadOnlyCollection<string>(maArray);
    Console.WriteLine(myReadOnlyCollection[0]); // would work fine since the collection is read-only
    Console.WriteLine(myReadOnlyCollection[1]); // would work fine since the collection is read-only
    Console.WriteLine(myReadOnlyCollection[2]); // would work fine since the collection is read-only
    myReadOnlyCollection[0] = "ServerFault"; // the [] accessor is neither defined nor would it be allowed since the collection is read-only.
