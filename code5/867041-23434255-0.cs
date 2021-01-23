            // Set the reader (PdfReader) and output (Stream) first
            PdfStamper stamper = PdfStamper.CreateSignature(reader, output, '\0');
            
            PdfSignatureAppearance signatureAppearance = stamper.SignatureAppearance;
            signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.GRAPHIC_AND_DESCRIPTION;
            signatureAppearance.Reason = "I love signing";
            signatureAppearance.LocationCaption = "";
            signatureAppearance.SignatureGraphic = Image.GetInstance(this.imageFolderPath + "sign.png");
            signatureAppearance.SetVisibleSignature(
                new Rectangle(100, 100, 300, 200), 
                reader.NumberOfPages, 
                "Signature");
            // Get certificate from store, here I am reading file
            X509Certificate2 cert = new X509Certificate2(certFile, certPassword);
            var keyPair = DotNetUtils.GetKeyPair(cert.PrivateKey).Private;
            BcX509.X509Certificate bcCert = DotNetUtils.FromX509Certificate(cert);
            var chain = new List<BcX509.X509Certificate> { bcCert };
            IExternalSignature signature = new PrivateKeySignature(keyPair, "SHA-256");
            MakeSignature.SignDetached(signatureAppearance, signature, chain, null, null, null, 0, CryptoStandard.CMS);
            stamper.Close();
