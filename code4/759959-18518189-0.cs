    using System.Text;
    // ...
    public static byte[] EmbedDataInString(string Cmd, byte Data)
    {
        byte[] ConvertedToByteArray = new byte[Cmd.Length + 2];
        System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(Cmd), 0, ConvertedToByteArray, 0, ConvertedToByteArray.Length - 2);
        ConvertedToByteArray[ConvertedToByteArray.Length - 2] = Data;
        /*Add on null terminator*/
        ConvertedToByteArray[ConvertedToByteArray.Length - 1] = (byte)0x00;
        return ConvertedToByteArray;
    }
