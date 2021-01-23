    public class MyClass {
    public int MyIntegerValue { get; private set; }
    public MyClass(int v) {
        MyIntegerValue = v;
        if(MyIntegerValue == 5) {
           DoA();
        } else {
           DoB();
        }
    }
    } 
