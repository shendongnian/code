    using (var binaryReader = new BinaryReader(Request.Files["files"].InputStream))
    {
        byte[] imagefile = binaryReader.ReadBytes(Request.Files["files"].ContentLength); //image
        using (MemoryStream memory = new MemoryStream(imagefile))
        using (Image bitmap = Image.FromStream(memory)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode(bitmap);
            decodedData = result.Text;
        }
    }
