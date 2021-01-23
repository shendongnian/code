    MyClass {
        public static List<Field> MyList {get;set;}
    }
    AnotherClass {
        MyClass instance = new MyClass();
        
        AnotherClass() {
            MyClass.MyList = // whatever
            // or also possible
            MyClass.MyList.Add(/*new Item*/);
        }
    }
 
