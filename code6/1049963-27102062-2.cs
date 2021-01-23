    MyClass {
        public static List<Field> MyList {get;set;}
    }
    AnotherClass {
        
        AnotherClass() {
            MyClass.MyList = // whatever
            // or also possible
            MyClass.MyList.Add(/*new Item*/);
        }
    }
 
