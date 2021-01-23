    byte[] request = StreamToByte(ResponseFromDevice);
    var signer = new SignedCms();
    signer.Decode(request);
    X509Certificate2 certificate = signer.Certificates[0];
    string xmlData = "payload string to encrypt";
                                                    
    Byte[] cleartextsbyte = UTF8Encoding.UTF8.GetBytes(xmlData);
    ContentInfo contentinfo = new ContentInfo(cleartextsbyte);
    EnvelopedCms envelopedCms = new EnvelopedCms(contentinfo);
    CmsRecipient recipient = new CmsRecipient(certificate);
    envelopedCms.Encrypt(recipient);
    string data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\"><plist version=\"1.0\"><dict><key>EncryptedPayloadContent</key><data>[ENCRYPTEDDATA]</data><key>PayloadDescription</key><string>For profile enrollment</string><key>PayloadDisplayName</key><string>ProfileName</string><key>PayloadIdentifier</key><string>YourIdentifier</string><key>PayloadOrganization</key><string>YourOrg</string><key>PayloadRemovalDisallowed</key><false/><key>PayloadType</key><string>Configuration</string><key>PayloadUUID</key><string>YourUDID/string><key>PayloadVersion</key><integer>1</integer></dict></plist>";
    data = data.Replace("[ENCRYPTEDDATA]", Convert.ToBase64String(envelopedCms.Encode()));
    HttpContext.Current.Response.Write(data);
    WebOperationContext.Current.OutgoingResponse.ContentType = "application/x-apple-aspen-config";
    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                        
