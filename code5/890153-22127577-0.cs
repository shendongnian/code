    // Create the MD5 hash object.
	System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create ();
	string password = "password";
	string salt = "salt";
	// Hash password and salt
	byte[] passwordHash = md5.ComputeHash (System.Text.Encoding.ASCII.GetBytes (password));
	byte[] saltHash = md5.ComputeHash (System.Text.Encoding.ASCII.GetBytes (salt));
	// Combine password and hash.
	string passwordAndSalt = System.Text.Encoding.ASCII.GetString (passwordHash) + System.Text.Encoding.ASCII.GetString (saltHash);
	// Compute final hash against the password and salt.
	byte[] finalHash = md5.ComputeHash (System.Text.Encoding.ASCII.GetBytes (passwordAndSalt));
