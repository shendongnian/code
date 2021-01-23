    //Case 1
    var image = JsonConvert.DeserializeObject<RoomImage>("{}");
    Console.WriteLine(image.Url); //<-- ~/no-picture-available.jpg
    //Case 2
    var settings = new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore };
    image = JsonConvert.DeserializeObject<RoomImage>("{\"Url\":null}", settings);
    Console.WriteLine(image.Url); //<-- ~/no-picture-available.jpg
---
    public class RoomImage
    {
        string _url = "~/no-picture-available.jpg";
        public string Url { get { return _url; } set { _url = value; } }
    }
