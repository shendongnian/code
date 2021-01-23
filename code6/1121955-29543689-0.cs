    public abstract class Parent {
        // logic for class
        public int Value {get;set;}
        public Parent(){}
    }
    public class Child1 : Parent {
        // child specific logic here
        public Child1 () : base() {
            base.Value = 4;
        }
    }
    public class Child2 : Parent {
        // child specific logic here
        public Child2 () : base() {
            base.Value = 6;
        }
    }
    public class RunMe {
        Parent p;
        public Parent instantiateObject(string s) {
            switch(s) {
                case "child1":
                    return new Child1();
                break;
                default:
                case "child2":
                    return new Child2();
                break;
            }
        }
        public RunMe() {
            p = instantiateObject("child1");
        }
    }
