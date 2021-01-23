    JavaScriptSerializer deserializer = new JavaScriptSerializer();
    deserializer.MaxJsonLength = 50000000;
    Dictionary<string, object> jsonObjects = (Dictionary<string, object>)deserializer.DeserializeObject(postData);
    string base64image = jsonObjects["imagestring"].ToString();              
    byte[] imagebytes = Convert.FromBase64String(base64image);
    Guid imagename = Guid.NewGuid();
    if (!Directory.Exists(EM.ImagePath))
       Directory.CreateDirectory(EM.ImagePath);
    using (FileStream sw = new FileStream(EM.ImagePath + imagename + ".jpg", FileMode.CreateNew))
    {
       sw.Write(imagebytes, 0, imagebytes.Length);
    }
