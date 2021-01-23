    private string _updatedText = string.Empty;
        public string UpdatedText
        {
            get { return _updatedText ; }
            set
            {
                _updatedText = value;
                OnPropertyChnaged("UpdatedText");
            }
        }
