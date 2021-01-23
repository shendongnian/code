    const string TemplateOid = "1.3.6.1.4.1.311.21.8.etc.etc";
    const int MajorVersion = 100;
    const int MinorVersion = 4;
    Dictionary<DerObjectIdentifier, X509Extension> extensionsDictionary = new Dictionary<DerObjectIdentifier,X509Extension>();
    DerObjectIdentifier certificateTemplateExtensionOid = new DerObjectIdentifier("1.3.6.1.4.1.311.21.7");
    DerSequence certificateTemplateExtension = new DerSequence(
        new DerObjectIdentifier(TemplateOid),
        new DerInteger(MajorVersion),
        new DerInteger(MinorVersion));
    extensionsDictionary[certificateTemplateExtensionOid] = new X509Extension(
        false,
        new DerOctetString(certificateTemplateExtension));
    X509Extensions extensions = new X509Extensions(extensionsDictionary);
    Attribute attribute = new Attribute(
        PkcsObjectIdentifiers.Pkcs9AtExtensionRequest,
        new DerSet(extensions));
    DerSet attributes = new DerSet(attribute);
    Pkcs10CertificationRequest csr = new Pkcs10CertificationRequest("SHA256WITHRSA", name, keyPair.Public, attributes, keyPair.Private);
