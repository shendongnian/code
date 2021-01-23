    class GunList
    {
        private satic GunList _GunList = new GunList();
        public static GunList Guns
        {
           get { return _GunList; }
        }
        private List<string> gunList = new List<string>();
        private GunList()
        {
             // Initialize here
        }
    }
