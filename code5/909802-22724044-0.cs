    for (int i  = 0; i < 100; i++)
    {
       using(MemoryStream ms = new MemoryStream())
       {
          BinaryWriter w = new BinaryWriter(ms);
          w.Write(i.ToString());
       }
    }
