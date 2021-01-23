    var obj = JsonConvert.DeserializeObject<RootObject>(json);
    Console.WriteLine(obj.data.img_url);
---
    public class Data
    {
        public string img_name { get; set; }
        public string img_url { get; set; }
        public string img_view { get; set; }
        public string img_width { get; set; }
        public string img_height { get; set; }
        public string img_attr { get; set; }
        public string img_size { get; set; }
        public int img_bytes { get; set; }
        public string thumb_url { get; set; }
        public int thumb_width { get; set; }
        public int thumb_height { get; set; }
        public string source { get; set; }
        public string resized { get; set; }
        public string delete_key { get; set; }
    }
    public class RootObject
    {
        public int status_code { get; set; }
        public string status_txt { get; set; }
        public Data data { get; set; }
    }
