    using Org.BouncyCastle.Cms;
    using Org.BouncyCastle.X509.Store;
    using System.Collections;
    using System.Security.Cryptography.Pkcs;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                // make some pkcs7 signedCms to work on
                SignedCms p7 = new SignedCms(new System.Security.Cryptography.Pkcs.ContentInfo(new byte[] { 0x01, 0x02 }));
                p7.ComputeSignature(new CmsSigner(), false);
    
                // encode to get signedCms byte[] representation
                var signedCms = p7.Encode();
    
                // load using bouncyCastle
                CmsSignedData sig = new CmsSignedData(signedCms);
    
                var allSigsValid = VerifySignatures(sig);
    
                byte[] content = sig.SignedContent.GetContent() as byte[];
            }
    
            // taken from bouncy castle SignedDataTest.cs
            private static bool VerifySignatures(
                CmsSignedData sp)
            {
                var signaturesValid = true;
                IX509Store x509Certs = sp.GetCertificates("Collection");
                SignerInformationStore signers = sp.GetSignerInfos();
    
                foreach (SignerInformation signer in signers.GetSigners())
                {
                    ICollection certCollection = x509Certs.GetMatches(signer.SignerID);
    
                    IEnumerator certEnum = certCollection.GetEnumerator();
                    certEnum.MoveNext();
                    Org.BouncyCastle.X509.X509Certificate cert = (Org.BouncyCastle.X509.X509Certificate)certEnum.Current;
    
                    signaturesValid &= signer.Verify(cert);
                }
                return signaturesValid;
            }
        }
    }
