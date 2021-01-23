     class Class1
        {
            public void test()
            {
                MethodInfo mi = this.GetType().GetMethod("test2");
                mi.Invoke(this, null);
            }
            public void test2()
            {
                Console.Out.WriteLine("Test2");
            }
        }
