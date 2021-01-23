        void MyDummyMethod(Guid? foo = null, Guid? bar = null, params int[] list)
        {
            //do work            
        }
        static void CallingDummyMethod()
        {
            MyClass variable = new MyClass { Prop = 1 };
            var ints = new int[] {1, 2};
            if (variable.Prop == 1)
            {
                MyDummyMethod(list: ints, foo: Guid.Empty);
            }                
            else
            {
                MyDummyMethod(list: ints, bar: Guid.Empty);
            }            
        }
