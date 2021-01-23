	public class Customer
    {
		
		[JsonProperty(PropertyName = "email")]			
        public string Email { get; set; }
        #if QA
			[JsonProperty(PropertyName = "prop[QA_ID]")]
		#elif STAGING
			[JsonProperty(PropertyName = "prop[STAGING_ID]")]
		#endif
        public string Test{ get; set; }
        // there are lot of properties 
    }
