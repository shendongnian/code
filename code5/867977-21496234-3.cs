    public void method1(){
        String s1="";
        String s1=getText();
        if(MyValidation.isOk(s1)){
           RunSomethingInternalForMethod1(s1);
           // or
           // if(RunSomethingInternalForMethod1(s1))
           //     RunSomethingInternalForMethod2(s1);
        }
    }
    
    public void method2(String s1){
        if(MyValidation.isOk(s1)){ 
            RunSomethingInternalForMethod2(s1);
        }
    }
    // PRIVATE HERE ... NO WAY TO CALL THIS FROM CODE EXTERNAL TO THIS CLASS
    private void RunSomethingInternalForMethod1(string s1){
        .....
        // You could call the additional internal code here, or add this 
        // call after the public method1, you could even change the return value
        // of this method and call the second one only if this one is successful
        RunSomethingInternalForMethod2(s1);
    }
    private void RunSomethingInternalForMethod2(string s1){
    
    }
