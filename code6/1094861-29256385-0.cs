        private static void MyMethod(out object MyPara)
        {
            MyPara = new String('x', 10);
        }
        MyClass obj = new MyClass();
        MyMethod(out obj); //compile time error
