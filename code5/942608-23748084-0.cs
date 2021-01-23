    static object GetMode(string userinput) {
        if (string.IsNullOrEmpty(userinput)) {
            // use try catch in main method
            throw new ArgumentException("Expected a value in the userinput");
            // OR
            return new ClassC();
        }
        userinput = userinput.toLower();
        if (string.Equals("a")) {
            return new ClassA();
        } else if (string.Equals("b")) {
            return new ClassB();
        }
        return new ClassC();
    }
