    public class RsaCsp2DerConverter {
       private const int MaximumLineLength = 64;
 
       // Based roughly on: http://stackoverflow.com/a/23739932/1254575
 
       public RsaCsp2DerConverter() {
 
       }
 
       public byte[] ExportPrivateKey(String cspBase64Blob) {
          if (String.IsNullOrEmpty(cspBase64Blob) == true)
             throw new ArgumentNullException(nameof(cspBase64Blob));
 
          var csp = new RSACryptoServiceProvider();
 
          csp.ImportCspBlob(Convert.FromBase64String(cspBase64Blob));
          
          if (csp.PublicOnly)
             throw new ArgumentException("CSP does not contain a private key!", nameof(csp));
 
          var parameters = csp.ExportParameters(true);
 
          var list = new List<byte[]> {
             new byte[] {0x00},
             parameters.Modulus,
             parameters.Exponent,
             parameters.D,
             parameters.P,
             parameters.Q,
             parameters.DP,
             parameters.DQ,
             parameters.InverseQ
          };
 
          return SerializeList(list);
       }
 
       private byte[] Encode(byte[] inBytes, bool useTypeOctet = true) {
          int length = inBytes.Length;
          var bytes = new List<byte>();
 
          if (useTypeOctet == true)
             bytes.Add(0x02); // INTEGER
 
          bytes.Add(0x84); // Long format, 4 bytes
          bytes.AddRange(BitConverter.GetBytes(length).Reverse());
          bytes.AddRange(inBytes);
          
          return bytes.ToArray();
       }
 
       public String PemEncode(byte[] bytes) {
          if (bytes == null)
             throw new ArgumentNullException(nameof(bytes));
 
          var base64 = Convert.ToBase64String(bytes);
 
          StringBuilder b = new StringBuilder();
          b.Append("-----BEGIN RSA PRIVATE KEY-----\n");
 
          for (int i = 0; i < base64.Length; i += MaximumLineLength)
             b.Append($"{ base64.Substring(i, Math.Min(MaximumLineLength, base64.Length - i)) }\n");
 
          b.Append("-----END RSA PRIVATE KEY-----\n");
 
          return b.ToString();
       }
 
       private byte[] SerializeList(List<byte[]> list) {
          if (list == null)
             throw new ArgumentNullException(nameof(list));
 
          var keyBytes = list.Select(e => Encode(e)).SelectMany(e => e).ToArray();
 
          var binaryWriter = new BinaryWriter(new MemoryStream());
          binaryWriter.Write((byte) 0x30); // SEQUENCE
          binaryWriter.Write(Encode(keyBytes, false));
          binaryWriter.Flush();
 
          var result = ((MemoryStream) binaryWriter.BaseStream).ToArray();
 
          binaryWriter.BaseStream.Dispose();
          binaryWriter.Dispose();
 
          return result;
       }
    }
