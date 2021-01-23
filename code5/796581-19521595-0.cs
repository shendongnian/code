    // Define other methods and classes here
    public class A
    {
        public int[] prop1;
        public string prop2;
        public string prop3;
        public A()
        {
        }
        public A(A orig)
        {
            prop1 = orig.prop1;
            prop2 = orig.prop2;
            prop3 = orig.prop3;
        }
    }
    public class B : A
    {
        public Dictionary<int, int> prop4;
        public B(int[] keys, A a) : base( a )
        {
            prop4 = new Dictionary<int, int>();
            if (keys.Length == prop1.Length)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    prop4.Add(keys[i], prop1[i]);
                }
            }
            else
            {
                throw new Exception("something wrong");
            }
        }
    }
