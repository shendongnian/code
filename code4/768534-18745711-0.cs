    public class ButtonImageInfo 
    {  
         public string ButtonId {get;set;}
         public string MouseEnterImage {get;set;}
         public string MouseLeaveImage {get;set;}
    }
    // ...
    public Dictionary<string, ButtonImageInfo> _dict = new ...
    _dict.Add("Button1", new ButtonImageInfo ("Button1", "Image1Enter", "Image1Leave"));
    ///    ... etc...
