    public static byte[] EmbedDataInString(string Cmd, byte Data)
        {
            byte[] ConvertedToByteArray = new byte[(Cmd.Length * sizeof(byte)) + 3];
            char[] Buffer = Cmd.ToCharArray();
            for (int i = 0; i < Buffer.Length; i++)
            {
                ConvertedToByteArray[i] = (byte)Buffer[i];
            }
            ConvertedToByteArray[ConvertedToByteArray.Length - 3] = Data;
            ConvertedToByteArray[ConvertedToByteArray.Length - 2] = (byte)0x0A;
            /*Add on null terminator*/
            ConvertedToByteArray[ConvertedToByteArray.Length - 1] = (byte)0x00;
            return ConvertedToByteArray;
        }
