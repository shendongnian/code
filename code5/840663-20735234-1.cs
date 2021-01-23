	public class User
	{
		[Required(ErrorMessage = "Enter le nom")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Enter l'émail")]
		public string Email { get; set; }
		[Required(ErrorMessage = "pas de mdp!!!!")]
		public string Password { get; set; }
	}
