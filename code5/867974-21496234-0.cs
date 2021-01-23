    public void method1(){
        String s1="";
        String s1=getText();
        if(MyValidation.isOk(s1)){
           RunSomethingInternalForMethod1(s1)
        }
    }
    
    public void method2(String s1){
        if(MyValidation.isOk(s1)){ 
            RunSomethingInternalForMethod2(s1);
        }
    }
    private void RunSomethingInternalForMethod1(string s1){
        RunSomethingInternalForMethod2(s1);
    }
    private void RunSomethingInternalForMethod2(string s1){
    
    }
