	public string CreatePasswordDigest(byte[] nonce, string createdTime, string password)
	{
		// combine three byte arrays into one
		byte[] time = Encoding.UTF8.GetBytes(createdTime);
		byte[] pwd = Encoding.UTF8.GetBytes(password);
		byte[] operand = new byte[nonce.Length + time.Length + pwd.Length];
		Array.Copy(nonce, operand, nonce.Length);
		Array.Copy(time, 0, operand, nonce.Length, time.Length);
		Array.Copy(pwd, 0, operand, nonce.Length + time.Length, pwd.Length);
		// create the hash
		var sha1Hasher = new SHA1CryptoServiceProvider();
		byte[] hashedDataBytes = sha1Hasher.ComputeHash(operand);
		return Convert.ToBase64String(hashedDataBytes);
	}
    CreatePasswordDigest(Convert.FromBase64String("UIYifr1SPoNlrmmKGSVOug=="), "2009-12-03T16:14:49Z", "test8")
