    string str="SMDR#0D#0APCCSMDR#0D#0A";
    byte[] bytes = new byte[str.Length * sizeof(char)];
    System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
     foreach (var item in bytes)
            {
                Response.Write((char)item);
            }
