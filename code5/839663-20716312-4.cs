        Object obj;
        using (TextReader sr = new StringReader(publicKey))
        {
            PemReader pem = new PemReader(sr);
            obj = pem.ReadObject();               
        }
        var par = obj as Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters;
        RSACryptoServiceProvider csp = new RSACryptoServiceProvider(1024);        
        //var pp = csp.ExportParameters(false); //works on native .NET, doesn't work on monotouch
        var pp = new RSAParameters();
        pp.Modulus = par.Modulus.ToByteArrayUnsigned(); //doesn't work with ToByteArray()
        pp.Exponent = par.Exponent.ToByteArrayUnsigned();                          
        csp.ImportParameters(pp);
        var cspBytes = csp.Encrypt(bytes, false); 
