    public class AModel
    {
		public AModel()
		{
			Animals = new List<Animal>();	
		}
    	public string Title { get; set; }
    	public string Website { get; set; }
    	public string Address1 { get; set; }
    	public string Address2 { get; set; }
    	public string City { get; set; }
    	public string Zip { get; set; }
    	public string State { get; set; }
    	public string Country { get; set; }
    	public List<Animal> Animals { get; set; }
    
    }
    
        public class Animal
        {
            public int ID { get; set; }
            public string Name { get; set; }        		
            public bool Checked { get; set; }           
        }
