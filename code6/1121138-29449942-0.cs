    public class Result
    {
        public int data_id { get; set; }
        public string name { get; set; }
        public int rarity { get; set; }
        public int restriction_level { get; set; }
        public string img { get; set; }
        public int type_id { get; set; }
        public int sub_type_id { get; set; }
        public string price_last_changed { get; set; }
        public int max_offer_unit_price { get; set; }
        public int min_sale_unit_price { get; set; }
        public int offer_availability { get; set; }
        public int sale_availability { get; set; }
        public int sale_price_change_last_hour { get; set; }
        public int offer_price_change_last_hour { get; set; }
    }
    public class RootObject
    {
        public int count { get; set; }
        public int page { get; set; }
        public int last_page { get; set; }
        public int total { get; set; }
        public List<Result> results { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            objFromApi_idToName("http://www.gw2spidy.com/api/v0.9/json/item-search/iron");
        }
        public static RootObject objFromApi_idToName(string url)
        {
            RootObject rootObject = null;
            RootObject tempRootObject = null;
            int page = 1;
            do
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/" + page);
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    var jsonReader = new JsonTextReader(reader);
                    var serializer = new JsonSerializer();
                    //return serializer.Deserialize<RootObject>(jsonReader);
                    tempRootObject = serializer.Deserialize<RootObject>(jsonReader);
                    if (rootObject == null)
                    {
                        rootObject = tempRootObject;
                    }
                    else
                    {
                        rootObject.results.AddRange(tempRootObject.results);
                        rootObject.count += tempRootObject.count;
                    }
                }
                page++;
            } while (tempRootObject != null && tempRootObject.last_page != tempRootObject.page);
            return rootObject;
        }
    }
