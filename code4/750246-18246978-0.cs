    using Newtonsoft.Json;
   
    public class jb
    {
         public DateTime Date { set; get; }
         public string Artist { set; get; }
         public int Year { set; get; }
         public string album { set; get; }
        
    }
    var jsonObject = new jb();
    
    jsonObject.Date = DateTime.Now;
    jsonObject.Album = "Me Against The World";
    jsonObject.Year = 1995;
    jsonObject.Artist = "2Pac";
    System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
             new System.Web.Script.Serialization.JavaScriptSerializer();
    string sJSON = oSerializer.Serialize(jsonObject );
