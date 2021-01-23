    private byte[] GetRawImageBytes()
    {
        var img = Image.FromFile(PATH_TO_TEST_IMAGE);
        byte[] bArray;
        using (var ms = new MemoryStream())
        {
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            bArray = ms.GetBuffer();
        }
        return bArray;
    }
