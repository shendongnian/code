    public class MyClass
        {
    
            private int _MyIntegerValue = 5;
            public int MyIntegerValue
            {
                get
                {
                    return _MyIntegerValue;
                }
                set
                {
                    _MyIntegerValue = value;
                }
            }
    
            public MyClass()
            {
                if (MyIntegerValue == 5)
                {
                    DoA();
                }
                else
                {
                    DoB();
                }
            }
    }
