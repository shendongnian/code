    public static byte[] Encrypt3(byte[] data, string pemFilename)
    	{
    		byte[] cipheredBytes = null;
    		try {
    			AsymmetricKeyParameter key = ReadAsymmetricKeyParameter(pemFilename);
    		
    			RsaEngine e = new RsaEngine();
    			
    			e.Init(true, key);
    		
    			//Debug.Log ("Encryption msg: " + inputMessage);
    			//cipheredBytes = GetBytes(inputMessage);
    			//Debug.Log ("bytes: " + GetString(cipheredBytes));
    			cipheredBytes = e.ProcessBlock(data, 0, data.Length);
    		}
    		catch (Exception e) {
    			Debug.Log (e.Message);	
    		}
    		return cipheredBytes;
    	}
