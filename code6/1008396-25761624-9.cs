    public Class1 { public int myVar1 = 10;}
    public Class2 : Class1 { public int myVar2;}
    
    public void MyMethod(){ 
        Class1 myC1 = new Class1();
        Class2 myC2 = new Class2 { myVar2 = 15};
    }
