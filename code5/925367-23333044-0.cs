        public byte[] SignMsg(
            Byte[] msg,
            X509Certificate2 signerCert)
        {
            //  Place message in a ContentInfo object.
            //  This is required to build a SignedCms object.
            ContentInfo contentInfo = new ContentInfo(msg);
 
            //  Instantiate SignedCms object with the ContentInfo above.
            //  Has default SubjectIdentifierType IssuerAndSerialNumber.
            //  Has default Detached property value false, so message is
            //  included in the encoded SignedCms.
            SignedCms signedCms = new SignedCms(contentInfo);
 
            //  Formulate a CmsSigner object, which has all the needed
            //  characteristics of the signer.
            CmsSigner cmsSigner = new CmsSigner(signerCert);
 
            //  Sign the PKCS #7 message.
            Console.Write("Computing signature with signer subject " +
                "name {0} ... ", signerCert.SubjectName.Name);
            signedCms.ComputeSignature(cmsSigner);
            Console.WriteLine("Done.");
 
            //  Encode the PKCS #7 message.
            return signedCms.Encode();
        }
