    public class CreateAccountViewModel
    {
    	public CustomerViewModel Customer { get; set; }
    
    	[Required]
    	[Display(Name = "User name")]
    	public string UserName { get; set; }
    
    	[Required]
    	[DataType(DataType.Password)]
    	[Display(Name = "Password")]
    	public string Password { get; set; }
    
    	[DataType(DataType.Password)]
    	[Display(Name = "Confirm password")]
    	public string ConfirmPassword { get; set; }
    }
    
    public class CustomerViewModel
    {
    	[Required]
    	[Display(Name = "Company Name")]
    	public String CompanyName { get; set; }
    	
    	[Required]
    	[Display(Name = "CVR")]
    	public String CVR { get; set; }
    
    	[Required]
    	[Display(Name = "First name")]
    	public String FirstName { get; set; }
    
    	[Required]
    	[Display(Name = "Last name")]
    	public String LastName { get; set; }
    
    	[Required]
    	[Display(Name = "Phone (mobile)")]
    	public String Phone { get; set; }
    
    	[Required]
    	[Display(Name = "E-mail")]
    	public String Email { get; set; }
    
    	public CustomerAddressViewModel Address { get; set; }
    }
    
    public class CustomerAddressViewModel
    {
    	[Required]
    	[Display(Name = "Streey")]
    	public String Street { get; set; }
    
    	[Required]
    	[Display(Name = "Postal code")]
    	public String PostalCode { get; set; }
    
    	[Required]
    	[Display(Name = "City")]
    	public String City { get; set; }
    
    	[Required]
    	[Display(Name = "Country")]
    	public String Country { get; set; }
    }
