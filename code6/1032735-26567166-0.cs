    struct Data
    {
        byte[][] TitleTypes;
    }
    static void Main(string[] args) 
    {
        var d = new Data();
        var field = typeof(Data).GetField("TitleTypes");
        var newValue = new byte[5];
        // This line fails because you are setting a field of type byte[][] with 
        // a value of byte[]
        field.SetValue(d, newValue);
    }
