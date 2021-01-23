      using (Stream filestream = new MemoryStream(sp.ImageFile)
      {
         var checkSeek = filestream.Seek(0, SeekOrigin.Begin);
         
         **// GET THE ERROR IN THIS LINE!**
         System.Drawing.Image image = System.Drawing.Image.FromStream(filestream);
      }   
 
