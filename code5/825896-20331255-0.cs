    public class Settings
    {
        public static ITheme Theme {get {return theme;}{set theme = value}}
        
        theme = new DefaultTheme();
    }
    public interface ITheme
    {
        public Color BackgroundColor {get;}
        public Color ButtonBackgroundColor { get;}
        
        //... etc
    }
    public class DefaultTheme : ITheme
    {
        public Color BackgroundColor {get{ return Color.White;}}
        public Color ButtonBackgroundColor { get { return Color.Gray;}}
    
    }
