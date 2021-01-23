    public class PatientPdo
    	{
    		public long Id{ get; set; }
    
    		public Entity ToEdmEntity()
    		{
    			return new Patient
    				{
    					Id= Id
    				};
    		}
    	}
