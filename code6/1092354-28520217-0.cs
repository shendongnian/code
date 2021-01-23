    [Serializable]
    public class Article
    {
        private string _fontItemString;
        public string Name { get; set; }
        [XmlIgnore]
        public FontFamily FontItem
        {
            get
            {
                return new FontFamily(FontItemString);
            }
        }
        public string FontItemString
        {
            get { return _fontItemString; }
            set
            {
                _fontItemString = value;
                RaisePropertyChanged(() => FontItem);
            }
        }
    }
