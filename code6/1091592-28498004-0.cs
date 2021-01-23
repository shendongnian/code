    //Clientside    
    byte[] imgBytes = File.ReadAllBytes("FilePath");
    string imgStr = System.Convert.ToBase64String(imgBytes);
    //Serverside 
    byte[] serverSideImgBytes = System.Convert.FromBase64String(imgStr);
    File.WriteAllBytes("PathAndFileName", serverSideImgBytes);
