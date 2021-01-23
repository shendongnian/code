    public class Record
    {
       [MessageHeader(ProtectionLevel=None)] public int recordID;
       [MessageHeader(ProtectionLevel=EncryptAndSign)] public string SSN;
       [MessageBodyMember(ProtectionLevel=None)] public string comments;
       [MessageBodyMember(ProtectionLevel=EncryptAndSign)] public string history;
    }
