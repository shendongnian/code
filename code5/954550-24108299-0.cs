	public class keyCreation
	{
		public byte[] Key1;
		public byte[] Key2;
		public byte[] Key3;
		public byte[] Key4;
		public byte[] Key5;
		public byte[] Key6;
		public byte[] Key7;
		public static keyCreation Key_Derivation_Function(byte[] password)
		{
			string salt = "12345678";
			byte[] saltbyte = Encoding.UTF8.GetBytes(salt);
			Console.WriteLine("Password length: " + password.Length);
			Console.WriteLine("Saltbyte lenght: " + saltbyte.Length);
			Rfc2898DeriveBytes keyGenerate = new Rfc2898DeriveBytes(password, saltbyte, 1000);
			return new keyCreation()
			{
				Key1 = keyGenerate.GetBytes(16),
				Key2 = keyGenerate.GetBytes(32),
				Key3 = keyGenerate.GetBytes(16),
				Key4 = keyGenerate.GetBytes(32),
				Key5 = keyGenerate.GetBytes(16),
				Key6 = keyGenerate.GetBytes(16),
				Key7 = keyGenerate.GetBytes(32)
			};
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			//user giving input
			Console.WriteLine("Plaintext:  ");
			string plaintext = Console.ReadLine();
			byte[] text = Encoding.UTF8.GetBytes(plaintext);
			Console.WriteLine("Enter Password: ");
			string pass = Console.ReadLine();
			byte[] password = Encoding.UTF8.GetBytes(pass);
			var result = keyCreation.Key_Derivation_Function(password);
			// get the keys and do something with the keys        
			var key1 = result.Key1;
			var key2 = result.Key2;
			...
		}
	}
