    sealed class MainViewModel : ViewModelNavigator
    {
        
        internal class HeaderButton
        {
            public string Content { get; set; }
            public BitmapImage Icon { get; set; }
            public PageContainerFactory.ContainerType ContainerType { get; set; }
            public bool IsSelected { get; set; }
        }
   ...
   
   
    private List<HeaderButton> _headerButtons;
    public List<HeaderButton> HeaderButtons
        {
            get
            {
                if (_headerButtons == null)
                    _headerButtons = new List<HeaderButton>();
                return _headerButtons;
            }
            set { _headerButtons = value; }
        }
