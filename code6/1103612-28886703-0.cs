    MyClass C1 = new MyClass();
    MYClass C2 = new MyClass();
    int[] x = new int[3] {1,2,3};
    C1.MyProperty = x;
    x[2] = 7;       //this changes C1.MyProperty to a value of {1,2,7}
    
    x = new int[3] {1,2,3};
    C2.MyProperty = x;
