	public class Account
	{
		[Required]
		[StringLength(20, MinimumLength = 4)]
		public string Username { get; set; }
		[Required]
		[StringLength(20, MinimumLength = 4)]
		[Compare("ConfirmPassword")]
		public string Password { get; set; }
		[Required]
		[StringLength(20, MinimumLength = 4)]
		[Compare("Password")]
		[DisplayName("Confirm Password")]
		public string ConfirmPassword { get; set; }
		[Required]
		[AgeValidation(21)]
		[DisplayName("Birth Date")]
		public DateTime BirthDate { get; set; }
	}
