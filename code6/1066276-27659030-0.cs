    using System;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    
    namespace ReadKeyFromCert
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			string base64X509Cert = @"-----BEGIN CERTIFICATE-----
    MIICnzCCAggCCQDbr9OvJHgzmDANBgkqhkiG9w0BAQUFADCBkzELMAkGA1UEBhMC
    RUUxETAPBgNVBAgMCEhhcmp1bWFhMRAwDgYDVQQHDAdUYWxsaW5uMREwDwYDVQQK
    DAhFZXRhc29mdDERMA8GA1UECwwIYmFua2xpbmsxFjAUBgNVBAMMDXBhbmdhbGlu
    ay5uZXQxITAfBgkqhkiG9w0BCQEWEmVldGFzb2Z0QG9ubGluZS5lZTAeFw0xNDEy
    MjQxNjI1MjdaFw0zNDEyMTkxNjI1MjdaMIGTMQswCQYDVQQGEwJFRTERMA8GA1UE
    CAwISGFyanVtYWExEDAOBgNVBAcMB1RhbGxpbm4xETAPBgNVBAoMCEVldGFzb2Z0
    MREwDwYDVQQLDAhiYW5rbGluazEWMBQGA1UEAwwNcGFuZ2FsaW5rLm5ldDEhMB8G
    CSqGSIb3DQEJARYSZWV0YXNvZnRAb25saW5lLmVlMIGfMA0GCSqGSIb3DQEBAQUA
    A4GNADCBiQKBgQDCi9usnv8rJLBeBgHhbM/80zPUOlkuH0uYrdzj/zxQSZS0QEoH
    yVvosEWqO34+17CzQ0sc34kzK5qhLws7AKetjLH7cpgmVH5YnQxKgZ2a5I5mpj02
    v9rjwDSKX2ZDXCeRUdnZa26beMcX/i1C9jxk9tpE2NWud910yHPRpnAQFwIDAQAB
    MA0GCSqGSIb3DQEBBQUAA4GBAFmlXa8NkR2OP0bC0EapmCaoObUG2WOi6Fhl2dBB
    PInJq6tzv+YtMbaIAPANo1EzBeBcQTRvxgGIrqE/JJkjDhOvwxjdNcxp7Mt+7hkk
    PI55KkKAfOeE0ss0EUcCdnyCGAXdhJfUCxJydg0PaVpE70FXUcLZcZXfT968mDOC
    NpaS
    -----END CERTIFICATE-----
    ";
    			base64X509Cert = base64X509Cert.Replace ("-----BEGIN CERTIFICATE-----", "");
    			base64X509Cert = base64X509Cert.Replace ("-----END CERTIFICATE-----", "");
    			var derCert = Convert.FromBase64String (base64X509Cert);
    			var x509 = new X509Certificate2 (derCert);
    			RSACryptoServiceProvider rsa = (RSACryptoServiceProvider) x509.PublicKey.Key;
    			Console.WriteLine (rsa.ToXmlString(false));
    		}
    	}
    }
