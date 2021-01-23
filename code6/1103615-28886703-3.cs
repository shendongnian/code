    MyClass C1 = new MyClass();
    MYClass C2 = new MyClass();
    int[] x = new int[3] {1,2,3};
    C1.MyProperty = x;
    x[2] = 7;       
    
    x = new int[3] {1,2,3};
    C2.MyProperty = x; 
    //You know have two arrays, {1,2,7} and {1,2,3}, which are accessible through C1 and C2
