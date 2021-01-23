    using (FileStream fs = new FileStream( absolute, FileMode.Open )) {
    	// create a CryptoStream in read mode
    	using (CryptoStream cryptoStream = new CryptoStream( fs, decryptor, CryptoStreamMode.Read )) {
    		int totalByte = ( int )fs.Length;
    		byte[] buffer = new byte[totalByte];
    		cryptoStream.Read( buffer, 0, totalByte );
    		using (MemoryStream ms = new MemoryStream( buffer )) {
    			BinaryFormatter bf = new BinaryFormatter( );
    			settings = ( SettingsJson )bf.Deserialize( ms );// Deserialize SettingsJson array
    		}
    	}
    	fs.Close( );
    }
