                    using (RijndaelManaged rm = new RijndaelManaged())
    				{
    					rm.BlockSize = 128;
    					Rfc2898DeriveBytes keyDerivator = new Rfc2898DeriveBytes(password, salt, KeyGenIterationCount); //derive key and IV from password and salt using the PBKDF2 algorithm
    					rm.IV = keyDerivator.GetBytes(16); //16 bytes (128 bits, same as the block size)
    					rm.Key = keyDerivator.GetBytes(32);
    
    					//(encrypt here)
    				}
