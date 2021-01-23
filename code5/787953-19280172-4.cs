    public clas ProductNote : Note 
    {	
    	public int ProductId { get; set; }
    	public virtual Product Product { get; set; }
    }
