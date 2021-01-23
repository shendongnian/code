    public void ViewImage(Byte[] ImageBytes)
    {
        try
        {
            Byte[] ba = new Byte[1];
            using (MemoryStream ms = new MemoryStream(ba))
            {
                Image img = Image.FromStream(ms);
                String tmpFile = Path.GetTempFileName();
                tmpFile = Path.ChangeExtension(tmpFile, "jpg");
                img.Save(tmpFile);
                if (File.Exists(tmpFile))
                    Process.Start(tmpFile);  //Windows will use file association to open a viewer
            }
        }
        catch (OutOfMemoryException ex)
        {
            //React appropriately
        }
    }
