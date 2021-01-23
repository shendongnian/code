    class MyClass {
        public List<object> property { get; private set; }
        public MyClass() {
            property = new List<object>(100);
        }
    }
    ...
    var myObj = new MyClass();
    myObj.property[0] = 1;
    myObj.property[1] = "hello";
