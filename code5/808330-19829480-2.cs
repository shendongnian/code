    void SomeMethod
    {
        foreach(Touch input in Inputlist){
            ThreadPool.QueueUserWorkItem(new WaitCallback(FilterInput), input);
        }
    }
    void FilterInput(object unCastUnFilteredInput){
        Touch UnFilteredInput = (Touch)unCastUnFilteredInput;
    ....
    }
