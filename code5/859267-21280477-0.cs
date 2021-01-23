    public struct Empty {
    	public static Empty Value {
            get { return default(Empty); }
    }
    static Task GetCompletedTask() { 
        return Task.FromResult(Empty.Value); } 
