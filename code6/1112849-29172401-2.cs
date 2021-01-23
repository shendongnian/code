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
    			byte[] buffer = new byte[2048];
				int readCount = 0;
				try
				{
					while ((readCount = fsInput.Read(buffer, 0, 2048)) > 0)
					{
						cryptostream.Write(buffer, 0, readCount);
					}
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
