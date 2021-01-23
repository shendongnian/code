    void Main()
    {
        Test t = new Test(17);
        t.Dump();
        t.StrangeMutation();
        t.Dump();
    }
    
    public struct Test
    {
        public readonly int Value;
    
        public Test(int value)
        {
            Value = value;
        }
    
        public void StrangeMutation()
        {
            this = new Test(42);
        }
    }
