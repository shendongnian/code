    public async Task LoadData(){ 
    
    }
    
    public async Task LoadOtherData() {
    
    }
    
    private async void loadData_Click_1(object sender, EventArgs e)
    {
    	var loadDataTask = LoadData();
    	var loadOtherDataTask = LoadOtherData();
    	await Task.WhenAll(loadDataTask, loadOtherDataTask);
    
    	updateGrids(myDictionary);
    } 
