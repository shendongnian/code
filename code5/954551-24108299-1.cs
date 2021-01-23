	public class keyCreation
	{
		public static void Key_Derivation_Function(byte[] password, out byte[] key1, out byte[] key2, ...)
		{
			string salt = "12345678";
			byte[] saltbyte = Encoding.UTF8.GetBytes(salt);
			Console.WriteLine("Password length: " + password.Length);
			Console.WriteLine("Saltbyte lenght: " + saltbyte.Length);
			Rfc2898DeriveBytes keyGenerate = new Rfc2898DeriveBytes(password, saltbyte, 1000);
			key1 = keyGenerate.GetBytes(16);
			key2 = keyGenerate.GetBytes(32);
			...
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			...
			byte[] key1, key2, ...;
			keyCreation.Key_Derivation_Function(password, out key1, out key2, ...);
			...
		}
	}
