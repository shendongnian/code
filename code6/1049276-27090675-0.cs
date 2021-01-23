    using System;
    using System.IO;
    using System.Text;
    using System.Security.Cryptography;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.OpenSsl;
    
    namespace DotNetToPkcs8Pem
    {
    	public class DotNetToPkcs8Pem
    	{
    
    		public static void Convert(string privXmlFilename, string privPkcs8Filename) {
    			StringBuilder sb = new StringBuilder ();
    			string line;
    			var xmlIn = new StreamReader (privXmlFilename);
    			while ((line = xmlIn.ReadLine ()) != null) {
    				sb.Append (line);
    			}
    			var xmlKey = sb.ToString ();
    			var rsa = RSA.Create ();
    			rsa.FromXmlString (xmlKey);
    			var bcKeyPair = DotNetUtilities.GetRsaKeyPair(rsa);
    			var pkcs8Gen = new Pkcs8Generator (bcKeyPair.Private);
    			var pemObj = pkcs8Gen.Generate ();
    			var pkcs8Out = new StreamWriter (privPkcs8Filename, false);
    			var pemWriter = new PemWriter (pkcs8Out);
    			pemWriter.WriteObject (pemObj);
    			pkcs8Out.Close ();
    		}
    
    		public static void Main (string[] args)
    		{
    			var xmlFile = "exportedDotNetPrivKey.xml";
    			var pkcs8File = "privkey.pk8";
    			Convert (xmlFile, pkcs8File);
    		}
    	}
    }
