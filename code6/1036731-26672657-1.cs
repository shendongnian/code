    ServicePointManager.ServerCertificateValidationCallback +=
        (sender,certificate,chain,sslPolicyErrors) => {
        if(((System.Net.HttpWebRequest)sender).Host.EndsWith("google.com") ){
            if(certificate.GetCertHashString() == "83BD2426329B0B69892D227B27FD7FBFB08E3B5E"){
                return true;
            }
            Console.WriteLine("Uh-oh, google.com cert fingerprint ({0}) is unexpected. Cannot continue.",certificate.GetCertHashString());
            return false;
        }
	Console.WriteLine("Unexpected SSL host, not continuing.");
    return false;
    }
