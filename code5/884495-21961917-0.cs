    using (MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes("C:\\temp\\test.jpg")))
    {
        Console.WriteLine(ms.Length);   //59922
    }
    
    Bitmap b = new Bitmap("C:\\temp\\test.jpg");
    using (MemoryStream ms = new MemoryStream())
    {
        b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
        Console.WriteLine(ms.Length);  //6220854
    }
    
    using (MemoryStream ms = new MemoryStream())
    {
        b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        Console.WriteLine(ms.Length); //59922
    }
           
     
