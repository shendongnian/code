    System.Drawing.Image newImage;
    string strFileName = GetTempFolderName() + "yourfilename.gif";
    if (byteArrayIn != null)
    {
        using (MemoryStream stream = new MemoryStream(byteArrayIn))
        {
            newImage = System.Drawing.Image.FromStream(stream);
            newImage.Save(strFileName);
            img.Attributes.Add("src", strFileName);
        }
    }
    else
    {
        Response.Write("No image data found!");
    }
