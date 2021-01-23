    public class Class2
    {    
        Class1 Obj = new Class1();
        
        public string test2;
        
        public void method2()
        {
            // at this point Obj has default value of test1 property
            Obj.method1(); // change state of Obj
            test2 = Obj.test1; // now test1 has value "xyz" assigned
        }    
    }
