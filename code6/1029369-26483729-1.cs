        private Dictionary<string, string> _ModelArticleTypeCodeToTitleMapFilteredByCategory = ModelArticleTypeCodeToTitleMap;
        public Dictionary<string, string> ModelArticleTypeCodeToTitleMapFilteredByCategory
        {
            get { return _ModelArticleTypeCodeToChangeTitleMap; }
            set
            {
                _ModelArticleTypeCodeToChangeTitleMap = value;             
                NotifyStaticPropertyChanged("ModelArticleTypeCodeToChangeTitleMap");
            }
        }
