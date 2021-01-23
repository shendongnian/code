    public void DpapiExample()
    {
    	// Adds a level of entropy to our encryption making our encrypted data more secure
    	string entropy = "603e0f3a0ef74faf93b5e6bc2c2f7c358107";
    	var dpapi = new Dpapi(entropy);
    	
    	string textToEncrypt = "I'm a secret";
    	
    	string encryptedText;
    	dpapi.TryEncrypt(textToEncrypt, out encryptedText);
    	Console.WriteLine ("Encrypting");
    	Console.WriteLine (textToEncrypt);
    	Console.WriteLine (encryptedText);
    
    	string decryptedText;
    	
    	dpapi.TryDecrypt(encryptedText, out decryptedText);
    	
    	Console.WriteLine ("\r\nDecrypting");
    	Console.WriteLine (encryptedText);
    	Console.WriteLine (decryptedText);	
    }
    
    public class Dpapi
    {
       private readonly byte[] entropy;
    
       public Dpapi(string entropy)
       {
           this.entropy = Encoding.UTF8.GetBytes(entropy);
       }
    
       public Dpapi(string entropy, Encoding encoding)
       {
           this.entropy = encoding.GetBytes(entropy);
       }
    
    	public bool TryDecrypt(string encryptedString, out string decryptedString)
       {
           if (string.IsNullOrWhiteSpace(encryptedString))
           {
               throw new ArgumentNullException("encryptedString");
           }
    
           decryptedString = string.Empty;
    
           try
           {
               byte[] encryptedBytes = Convert.FromBase64String(encryptedString);
               byte[] decryptedBytes = ProtectedData.Unprotect(encryptedBytes, this.entropy, DataProtectionScope.LocalMachine);
               decryptedString = Encoding.UTF8.GetString(decryptedBytes);
           }
           catch
           {
               return false;
           }
    
           return true;
       }
    
       public bool TryEncrypt(string unprotectedString, out string encryptedString)
       {
           if (string.IsNullOrWhiteSpace(unprotectedString))
           {
               throw new ArgumentNullException("unprotectedString");
           }
    
           encryptedString = string.Empty;
    
           try
           {
               byte[] unprotectedData = Encoding.UTF8.GetBytes(unprotectedString);
               byte[] encryptedData = ProtectedData.Protect(unprotectedData, this.entropy, DataProtectionScope.LocalMachine);
               encryptedString = Convert.ToBase64String(encryptedData);
           }
           catch
           {
               return false;
           }
    
           return true;
       }
    }
