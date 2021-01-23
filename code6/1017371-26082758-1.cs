		public static void HashPassword(string Password, out string Salt, out string Hash)
		{
			System.Security.Cryptography.SHA1Managed sha = new System.Security.Cryptography.SHA1Managed();
			Random rnd = new Random();
			byte[] s = new byte[20];
			rnd.NextBytes(s);
			Salt = Convert.ToBase64String(s);
			System.Text.UTF8Encoding u = new UTF8Encoding();
			byte[] pass = u.GetBytes(Password);
			byte[] all = new byte[pass.Length + s.Length];
			Array.Copy(pass, all, pass.Length);
			Array.Copy(s, 0, all, pass.Length, s.Length);
			Byte[] H = sha.ComputeHash(all);
			Hash = Convert.ToBase64String(H);
		}
		public bool IsPasswordCorrect(string Password, string Salt, string Hash)
		{
			System.Security.Cryptography.SHA1Managed sha = new System.Security.Cryptography.SHA1Managed();
			byte[] s = Convert.FromBase64String(Salt);
			System.Text.UTF8Encoding u = new UTF8Encoding();
			byte[] pass = u.GetBytes(Password);
			byte[] all = new byte[pass.Length + s.Length];
			Array.Copy(pass, all, pass.Length);
			Array.Copy(s, 0, all, pass.Length, s.Length);
			Byte[] H = sha.ComputeHash(all);
			return (Hash == Convert.ToBase64String(H));
		}
