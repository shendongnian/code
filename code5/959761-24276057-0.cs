    class TagInfo
    {
        public string TagName {get; set;}
        private readonly List<string> data = new List<string>();
        public string Data {get {return data;}}
    }
