    for (int i = 0; i < this.Request.Files.Count; i++)
    {
       var file = this.Request.Files[i];
      
       //
       // ContentLength comes in bytes, you must convert it to MB and then
       // compare with 100 MB
       //
       if(file.ContentLength / 1024 / 1024 > 100)
       {
          TempData["Status"] += file.FileName + " has It size greater than 100MB";
       }
       else
       {
         string path = AppDomain.CurrentDomain.BaseDirectory + "uploads/";
         string filename = Path.GetFileName(file.FileName);
         file.SaveAs(Path.Combine(path, filename));
       }
    }
