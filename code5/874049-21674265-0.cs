    Dictionary<string, System.Drawing.Image> imageList = new Dictionary<string,System.Drawing.Image>(); 
    
    //filling imageList
    
    Thread thread = new Thread(() =>
    {
       foreach (KeyValuePair<string, System.Drawing.Image> image in imageList)
        {
           image.Value.Save(item.Key, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    });
    thread.Start();
