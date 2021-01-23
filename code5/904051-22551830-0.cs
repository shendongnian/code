    public async Task<string> Combine(Task<string> a, Task<string b){
        var aa = await a;
        var bb = await b;
        return aa + bb;	
    }
    
