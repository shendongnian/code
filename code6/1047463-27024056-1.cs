    Pkcs12Store store = new Pkcs12Store(new FileStream(KEYSTORE, FileMode.Open), PASSWORD);
    String alias = "";
    ICollection<X509Certificate> chain = new List<X509Certificate>();
    // searching for private key
    foreach (string al in store.Aliases)
        if (store.IsKeyEntry(al) && store.GetKey(al).Key.IsPrivate) {
            alias = al;
            break;
        }
    AsymmetricKeyEntry pk = store.GetKey(alias);
    foreach (X509CertificateEntry c in store.GetCertificateChain(alias))
        chain.Add(c.Certificate);
    RsaPrivateCrtKeyParameters parameters = pk.Key as RsaPrivateCrtKeyParameters;
    
    PdfReader reader = new PdfReader(src);
    FileStream os = new FileStream(dest, FileMode.Create);
    PdfStamper stamper = PdfStamper.CreateSignature(reader, os, '\0');
    // Creating the appearance
    PdfSignatureAppearance appearance = stamper.SignatureAppearance;
    appearance.Reason = "My reason for signing";
    appearance.Location = "The middle of nowhere";
    appearance.SetVisibleSignature(new Rectangle(36, 748, 144, 780), 1, "sig");
    // Creating the signature
    IExternalSignature pks = new PrivateKeySignature(pk, DigestAlgorithms.SHA256);
    MakeSignature.SignDetached(appearance, pks, chain, null, null, null, 0, CryptoStandard.CMS);
    
