    var entity = MimeEntity.Load (stream);
    
    if (entity is MultipartSigned) {
        var signed = (MultipartSigned) entity;
        foreach (var signature in signed.Verify ()) {
            try {
                bool valid = signature.Verify ();
                // If valid is true, then it signifies that the signed content has
                // not been modified since this particular signer signed the content.
                //
                // However, if it is false, then it indicates that the signed content
                // has been modified.
            } catch (DigitalSignatureVerifyException) {
                // There was an error verifying the signature.
            }
            // If you'd like to get a copy of the certificate used for signing,
            // you could do this:
            var wrapper = (SecureMimeDigitalCertificate) signature.Certificate;
            var cert = wrapper.Certificate;
            // The cert is a BouncyCastle X509Certificate, so if you want to convert
            // it to a System.Security X509Certificate2, you can do this:
            var x509certificate2 = new X509Certificate2 (cert.GetEncoded ());
        }
    }
