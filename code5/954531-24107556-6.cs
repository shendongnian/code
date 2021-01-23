    while (rdr1.Read())
    {
       byte[] data = (byte[])reader[0]; // 0 is okay if you only selecting one column
       //And use:
       using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
       {
          Image image = new Bitmap(ms);
       }
    }
