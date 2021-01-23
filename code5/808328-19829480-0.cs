    void SomeMethod
    {
        foreach(Touch Input in Inputlist){
            ThreadPool.QueueUserWorkItem(new WaitCallback(FilterInput), Input);
        }
    }
    void FilterInput(object unCastUnFilteredInput){
        Input UnFilteredInput = (Input)unCastUnFilteredInput;
    ....
    }
