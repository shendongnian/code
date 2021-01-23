    //Write the byte
    BinaryWriter bw = new BinaryWriter(File.OpenWrite("1.txt"));
    bw.BaseStream.Position = 3;
    bw.Write((byte)0x01);
    bw.Close();
    Console.WriteLine("Wrote the byte 01 at offset 3!");
    //Find the byte
    BinaryReader br = new BinaryReader(File.OpenRead("1.txt"));
    for (int i = 0; i <= br.BaseStream.Length; i++)
    {
         if (br.BaseStream.ReadByte() == (byte)0x01)
         {
              Console.WriteLine("Found the byte 01 at offset " + i);
              break;
         }
    }
    br.Close();
