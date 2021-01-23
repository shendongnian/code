     try
      {
      X509Certificate theSigner = X509Certificate.CreateFromSignedFile("c:\\r\\1.dll");
      Console.Write("certificate info :"+ theSigner.GetCertHashString());
      }
      catch (Exception ex)
      {
             Console.WriteLine("No digital signature ");
    
   
      }
