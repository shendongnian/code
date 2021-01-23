    public class AModel
    {
		public AModel()
		{
			Countries = new List<Country>();	
		}
    	public string Title { get; set; }
    	public string Website { get; set; }
    	public string Address1 { get; set; }
    	public string Address2 { get; set; }
    	public string City { get; set; }
    	public string Zip { get; set; }
    	public string State { get; set; }
    	public string Country { get; set; }
        // Country collection
    	public List<Country> Countries { get; set; }
    
    }
    
        public class Country
        {
            public int ID { get; set; }
            public string Name { get; set; }        		
            public bool Checked { get; set; }           
        }
