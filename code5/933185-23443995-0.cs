     const string formatter = "{0,16:E7}{1,20}";
    // Convert a float argument to a byte array and display it. 
    public static void GetBytesSingle( float argument )
    {
        byte[ ] byteArray = BitConverter.GetBytes( argument );
        Console.WriteLine( formatter, argument, 
            BitConverter.ToString( byteArray ) );
    }
