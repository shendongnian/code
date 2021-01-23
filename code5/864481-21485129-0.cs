    //Parameter binary is a bit string
    public void someroutine(String binary) 
    {
     var data = GetBytesFromBinaryString(binary);
     var text = Encoding.ASCII.GetString(data);
    }
    
    public Byte[] GetBytesFromBinaryString(String binary)
    {
     var list = new List<Byte>();
     for (int i = 0; i < binary.Length; i += 8)
         {
         String t = binary.Substring(i, 8);
         list.Add(Convert.ToByte(t, 2));
         }
     return list.ToArray();
    }
