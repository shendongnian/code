    [WebMethod]
    public static string ProcessIT()
    {
    var bitmap = DrawingMethod(); //Method that draws dynamically Bmp Image 
    MemoryStream ms = new MemoryStream();
    bitmap.Save(ms, ImageFormat.Jpeg);
    var base64Data = Convert.ToBase64String(ms.ToArray());
    string img = "data:image/gif;base64," + base64Data;
    return img; //The Gif image i want to display on the page
    }
