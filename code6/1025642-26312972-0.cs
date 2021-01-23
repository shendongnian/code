    wb.SaveAs(filePath);
    //encrypt the file
    Encrypt(filePath);
    using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            byte[] bytes = new byte[file.Length];
            file.Read(bytes, 0, (int)file.Length);
            memoryStream.Write(bytes, 0, (int)file.Length);
            memoryStream.WriteTo(HttpContext.Response.OutputStream);
        }
    }
