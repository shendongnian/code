    public enum commands {stop, wait, go};
    
    public class derivedClass : baseClass <commands>
    {
        override void useCommands (commands meh)
        {
             .
             .
             .
        }
    }
