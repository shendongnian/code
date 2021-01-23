    void Main()
    {
         //IRepository<Website> _repository =  ;
    	 
    	var _repository = new Repository.Pattern.Ef6.Repository<Website>(this);
    	
    	var website = _repository
    		.Query()
    		.Select();
    
    	website.Dump("The Oputput...");
    }
