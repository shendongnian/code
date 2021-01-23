    var lst = originalWorkbook.GetAllPictures();
    for (int i = 0; i < lst.Count; i++)
    {
        var pic = (XSSFPictureData) lst[i];
        byte[] data = pic.Data;
        BinaryWriter writer = new BinaryWriter(File.OpenWrite(String.Format("{0}.jpeg", i)));
        writer.Write(data);
        writer.Flush();
        writer.Close();
    }
