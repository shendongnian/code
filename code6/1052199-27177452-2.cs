	public class EditCustomerModel
	{
		[Required(ErrorMessage="*")]
		public string FirstName { get; set; }
		
		[Required(ErrorMessage="*")]
		public string LastName { get; set; }
		
		// and so on...
	}
