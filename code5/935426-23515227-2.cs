    public void AddFile(string fileName){
    	using(var ctx = new MyDbContext() ){
    		ctx.Files.Add(new File() { FullPath = fileName });
    		ctx.SaveChanges();
    	}
    }
