    class MyOuterClass {
        string outerClassName { get; set; }
        class MyInnerClass {
            string innerClassName { get; set; }
        }
        MyInnerClass myInnerClass = new MyInnerClass() {
            innerClassName = "inner";
        }
    }
