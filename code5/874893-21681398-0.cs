    public class CarImage
        {
            public int CarImageID { get; set; }
            public int CarID { get; set; }
            public string imageUrl { get; set; }
            public string thumbnail { get; set; }
    
            public virtual Car Car { get; set; }
        }
