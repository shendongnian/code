    public class RateInfo 
    {
        public string begin { get; set; }
        public string end { get; set; }
        public string price { get; set; }
        public string comment { get; set; }
        public string phone { get; set; }
        public string ImagePath { get; set; }
        public string what { get; set; }
        public string distance { get; set; }
    }    
    public ObservableCollection<RateInfo> Phones { get; set; }
    public List<RateInfo> LRate { get; set; }
    public ObservableCollection<RateInfo> Phones { get; set; }
    public List<RateInfo> LRate { get; set; }
    ......
    foreach (var item in ph)
            {
                
                LRate.Add(new RateInfo { begin = item["begin"].ToString(), end = item["end"].ToString(), price = item["price"].ToString(), distance=kilom, ImagePath = "chel.png" });
            }
           LRate.Sort((x, y) => x.distance.CompareTo(y.distance));
         
            foreach (var item in LRate)
            {
                Phones.Add(item);
            }
