    public enum commands {stop, wait, go};
    
    public class derivedClass : baseClass <commands>
    {
        protected override void useCommands (commands meh)
        {
             .
             .
             .
        }
    }
