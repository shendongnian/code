    public static class Shared
    {
        private static Class1 _myclass;
    
        public static Class1 MyClass{
             return _myclass??(_myclass=new Class1());
        }
    }
