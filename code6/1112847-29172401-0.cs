    private static void EncryptFile(string sInputFilename, 
        string sOutputFilename, string sKey)
    {
        using(FileStream fsInput =  new FileStream(sInputFilename, FileMode.Open, FileAccess.Read),
    			FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write))
    	{
    
    		DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
    
    		DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
    		DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
    		ICryptoTransform desencrypt = DES.CreateEncryptor();
    
    		using(CryptoStream cryptostream = 
    			new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write))
    		{
    			try
    			{
    				byte[] bytearrayinput = System.IO.File.ReadAllBytes(sInputFilename);
    				fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
    				cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
    			}
    			catch (Exception ex)
    			{
    				string error = "";
    
    				foreach (DictionaryEntry pair in ex.Data)
    				{
    					error += pair.Key + " = " + pair.Value + "\n";
    					Console.WriteLine(error);
    				}
    
    				LogWriter(error, true);
    			}
    		}
    	}
    }
