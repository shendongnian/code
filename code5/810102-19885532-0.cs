    args = "client 0";
    Stream str = tcp.GetStream();
    ASCIIEncoding asen = new ASCIIEncoding();
    byte[] b = asen.GetBytes(args);
    if(b.Length > 255)
        throw new InvalidDataException("Messages must have a length less than 256");
    str.WriteByte(b.Length);
    str.Write(b, 0, b.Length);
