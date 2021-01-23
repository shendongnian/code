        static int ImageCount = 0;
        static int currentImage = 0;
        Images HTTP = new Images();
        List<string> UrlList;
        static List<string> ImageCollection = new List<string>();
        public List<string> Images
        {
            get
            {
                return ImageCollection;
            }
            set
            {
                ImageCollection = value;
            }
        }
        public int CurrentImage
        {
            get
            {
                return currentImage;
            }
            set
            {
                currentImage = value;
            }
        }
        public int Count
        {
            get
            {
                return ImageCount;
            }
            set
            {
                ImageCount = value;
            }
        }
        public List<string> URLS
        {
            get
            {
                return UrlList;
            }
            set
            {
                UrlList = value;
            }
        }
