    public async Task<IList<int>> GetNumbers() 
    {
    	var listsSharedWithMe = new ObservableCollection<int>();
    	await Task.Delay(2000);
    	for (int i = 0; i < 5; i++)
    		listsSharedWithMe.Add(i);
    
    	return listsSharedWithMe;
    }
