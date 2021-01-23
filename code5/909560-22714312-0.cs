    public class MyCmbItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string APropertyName)
        {
            var property_changed = PropertyChanged;
            if (property_changed != null)
            {
                property_changed(this, new PropertyChangedEventArgs(APropertyName));
            }
        }  
        private string _Text;
        private string _KeyText;
        public int Index { get; set; }
        
	      public string Text
	      {
		      get { return _Text;}
		
		      set { 
			      if (_Text != value)
			      {
                      _Text = value;
				      NotifyPropertyChanged("Text");
			      }
		      }
	      }	
      
        public MyCmbItem(string key_text, int index)
        {
            Index = index;
            _KeyText = key_text;
            RefreshText();
            _res_man_global.LanguageChanged += () => RefreshText();
        }
        public void RefreshText()
        {
            Text = _res_man_global.GetString(_KeyText, _culture);
        }
    }
