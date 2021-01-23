    public class LanguageSelectorViewModel
    {
        private bool _isChinese;
        private bool _isEnglish;
        public bool IsChinese
        {
            get { return _isChinese; }
            set
            {
                _isChinese = value;
                if (value)
                    SelectedLanguage = "Chinese";
            }
        }
        public bool IsEnglish
        {
            get { return _isEnglish; }
            set
            {
                _isEnglish = value;
   
                if (value)
                    SelectedLanguage = "English";
            }
        }
        public string SelectedLanguage { get; set; }
    }
