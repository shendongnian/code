    ...
    [WebMethod()]
    public static void UploadImage(string imageData)
    {
    	string fileNameWitPath = "custom_name.png";
    	using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
    	{
    		using (BinaryWriter bw = new BinaryWriter(fs))
    		{
    			byte[] data = Convert.FromBase64String(imageData);//convert from base64
    			bw.Write(data);
    			bw.Close();
    		}
    	}
    }
    ...
