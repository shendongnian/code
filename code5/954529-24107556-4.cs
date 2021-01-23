    while (rdr1.Read())
    {
       byte[] data = (byte[])reader[0]; //if you return only one column so 0 is ok
       //And use:
       using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
       {
          Image image = new Bitmap(ms);
       }
    }
