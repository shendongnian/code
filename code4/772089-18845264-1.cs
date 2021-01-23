    string s = "<img src=\""+getImageFromFile("~/Content/skin/Office2010Blue.png","image/png")+"\" style=\"width: 100px;height: 100px;\" />";
    var html = new HtmlDocument();
    
    
    
    @html.CreateElement(s)
    
    
    public string getImageFromFile(String url, String imgType)
    {
        using (FileStream fs = new FileStream(Server.MapPath(url), 
                                       FileMode.Open, 
                                       FileAccess.Read)){
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
        }
        string encodedData = Convert.ToBase64String(filebytes);
        return "data:"+imgType+";base64,+"encodedData; 
    }
