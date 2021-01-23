    interface IMyInterface {
        int MyInterfaceMemberFunction();
    }
    
    public class MyObjectClass : IMyInterface {
        // this line changed:
        int IMyInterface.MyInterfaceMemberFunction() { return 17; }
    }
    
    public class MyTestClass {
        public int MyTestFunction() {
            MyObjectClass m = new MyObjectClass();
            //return m.MyInterfaceMemberFunction(); //error here
            return ((IMyInterface)m).MyInterfaceMemberFunction(); //this works
        }
    }
