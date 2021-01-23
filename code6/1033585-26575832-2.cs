    static void TestValue(double d)
    {
        Console.WriteLine("value is {0}, IsSubnormal returns {1}, IsNormal returns {2}", d, IsSubnormal(d), IsNormal(d));
    }
    
    static void TestValueBits(ulong bits)
    {
        TestValue(BitConverter.Int64BitsToDouble((long)bits));
    }
    
    public static void Main(string[] args)
    {
        TestValue(0.0);
        TestValue(1.0);
        TestValue(double.NaN);
        TestValue(double.PositiveInfinity);
        TestValue(double.NegativeInfinity);
        TestValue(double.Epsilon);
        TestValueBits(0xF000000000000000);
        TestValueBits(0x7000000000000000);
        TestValueBits(0xC000000000000000);
        TestValueBits(0x4000000000000000);
        TestValueBits(0xFFF0000000000005);
        TestValueBits(0x7FF0000000000005);
        TestValueBits(0x8010000000000000);
        TestValueBits(0x0010000000000000);
        TestValueBits(0x8001000000000000);
        TestValueBits(0x0001000000000000);
    }
