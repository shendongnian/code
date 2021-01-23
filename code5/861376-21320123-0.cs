    public void firstMethod()
    {
        for(int i = 0; i<10; i++)
        {
            aMethod();//call the method "aMethod()" 10 times
        }
    }
    //outside of the method containing the loop
    public void aMethod() {
        //do some stuff in the method
    }
