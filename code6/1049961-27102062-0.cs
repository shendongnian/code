    MyClass {
        public List<string> MyList {get;set;}
    }
    AnotherClass {
        MyClass instance = new MyClass();
        
        AnotherClass() {
            this.instance.MyList = // whatever
        }
    }
 
