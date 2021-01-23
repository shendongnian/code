	public class LoginViewModel
	{
			[Required]
			[StringLength(30, MinimumLength = 6)]
			[Display(Name = "Username")]
			public string UserName { get; set; }
			[Required]
			[StringLength(100)]
			[DataType(DataType.Password)]
			public string Password { get; set; }
	}
