            public static string CheckSignature(string FileName)
        {
            //X509Certificate2 cert;
            try
            {
                var signer = X509Certificate.CreateFromSignedFile(FileName);
                var cert = new X509Certificate2(signer);
                return "Digitally signed by: " + cert.SubjectName.Name;
            }
            catch (Exception)
            {
                return "NOT digitally signed.";
            }
        }
