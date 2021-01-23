    IsBusy = true;
    
    await MyFunction();
    
    IsBusy = true;
    
    ....
    private async void MyFunction()
    {
    	(..my logic code..)
    }
