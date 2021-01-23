    public class PageViewModel : NotifyingObject
    {
        public Theme CurrentTheme
        {
            get { return _currentTheme; }
            set
            {
                if (value == _currentTheme) return;
                _currentTheme = value;
                NotifyPropertyChanged("CurrentTheme");
            }
    	}
    	public IList<Theme> Themes
        {
            get { return _themes; }
            set
            {
                if (value == _themes) return;
                _themes = value;
                NotifyPropertyChanged("Themes");
            }
    	}
    }
