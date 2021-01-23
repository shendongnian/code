    class OuterClass
    {
        static int Number;
        class InnerClass
        {
            public InnerClass(int Number)
            {
                OuterClass.Number = Number;   
            }
        }
    }
