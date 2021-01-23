    public clas PersonNote : Note 
    {	
    	public int PersonId { get; set; }
    	public virtual Person Person { get; set; }
    }
