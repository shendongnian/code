    public abstract class ConsoleTheme
    {
        public abstract ConsoleColor BackgroundColor { get; }
    }
    public class LightTheme : ConsoleTheme
    {
        public override ConsoleColor BackgroundColor
        {
            get
            {
                return ConsoleColor.Black;
            }
        }
    }
