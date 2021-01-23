     using (var fs = new System.IO.FileStream(...)) {
         var ms = new System.IO.MemoryStream();
         fs.CopyTo(ms);
         ms.Position = 0;                               // <=== here
         if (pic.Image != null) pic.Image.Dispose(); 
         pic.Image = Image.FromStream(ms);
     } 
