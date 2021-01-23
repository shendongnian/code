    int tagMake = 0x010F;  // 271
    int tagModel = 0x0110; // 272
    Image image = Image.FromFile(@"C:\image.jpg");
    
    byte[] make = image.PropertyItems.Single(x => x.Id == tagMake).Value;
    byte[] model = image.PropertyItems.Single(x => x.Id == tagModel).Value;
    var encoding = new System.Text.ASCIIEncoding();
    Console.WriteLine(encoding.GetString(make));  // Returns: Canon
    Console.WriteLine(encoding.GetString(model)); // Returns: Canon PowerShot S40
