       void MyDummyMethod(int one, int two, int three, Guid? foo = null, Guid? bar = null)
        {
            //do work            
        }
        static void CallingDummyMethod()
        {
            MyClass variable = new MyClass { Prop = 1 };            
            if (variable.Prop == 1)
            {
                MyDummyMethod(1,2,3, foo: Guid.Empty);
            }                
            else
            {
                MyDummyMethod(1,2,3, bar: Guid.Empty);
            }            
        }
