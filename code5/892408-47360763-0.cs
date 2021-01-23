    var certificateSerialNumber= "‎83 c6 62 0a 73 c7 b1 aa 41 06 a3 ce 62 83 ae 25".ToUpper().Replace(" ", string.Empty);
    
    //0 certs
    var certs = store.Certificates.Find(X509FindType.FindBySerialNumber, certificateSerialNumber, true);
    
    //null
    var cert = store.Certificates.Cast<X509Certificate>().FirstOrDefault(x => x.GetSerialNumberString() == certificateSerialNumber);
    //1 cert
    var cert1 = store.Certificates.Cast<X509Certificate>().FirstOrDefault(x =>
                    x.GetSerialNumberString().Equals(certificateSerialNumber, StringComparison.InvariantCultureIgnoreCase));
