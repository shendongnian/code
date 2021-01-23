    public class Theme : INotifyPropertyChanged      
    {
    public event PropertyChangedEventHandler PropertyChanged;
    
    private string themeText;
    public string ThemeText
    {
        get
        {
            return themeText;
        }
        set
        {
            themeText = value;
            OnPropertyChanged("ThemeText");
        }
    }
    
    private int fontSize;
    public int FontSize
    {
        get
        {
            return fontSize;
        }
        set
        {
            fontSize = value;
            OnPropertyChanged("FontSize");
        }
    }
    
    private Brush fontColor;
    public Brush FontColor
    {
        get
        {
            return fontColor;
        }
        set
        {
            fontColor = value;
            OnPropertyChanged("FontColor");
        }
    }
    
    protected void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler handler = this.PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(name));
    }   
    }
