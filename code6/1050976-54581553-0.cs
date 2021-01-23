using (StreamReader file = new StreamReader(filepath))
{
    // store checksum
    Checksum = file.BaseStream.ToMD5Hash();	
    ....
}
extension method:
public static string ToMD5Hash(this System.IO.Stream stream)
{
    string hash = string.Empty;
    long position = stream.Position;
    // Initialize a hash object
    using (System.Security.Cryptography.MD5 myHasher = System.Security.Cryptography.MD5.Create())
    {
        // Be sure it's positioned to the beginning of the stream
        stream.Position = 0;
        // Compute the hash of the stream and convert to a string
        hash = myHasher.ComputeHash(stream).ByteArrayToString();
    }
    // reset location
    stream.Position = position;			
    return hash;
}
