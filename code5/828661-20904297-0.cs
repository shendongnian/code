    foreach (PgpPublicKeyRing kRing in pgpPub.GetKeyRings())
    {
    	foreach (PgpPublicKey k in kRing.GetPublicKeys())
    	{
    		if (k.IsEncryptionKey)
    		{
    			MemoryStream memStream = new MemoryStream();
    			ArmoredOutputStream armoredStream = new ArmoredOutputStream(memStream);
    			k.Encode(armoredStream);
    			armoredStream.Close();
    
    			string keyString = Encoding.ASCII.GetString(memStream.ToArray());
    			//...
    		}
    	}
    } 
