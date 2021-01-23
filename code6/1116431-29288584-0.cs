    public class ExtendedMessage : Message 
    {
        public ExtensionBase Extension { get; set; }
    }
    public abstract class ExtensionBase
    {
    }
    ...
    var extendedMessage = message as ExtendedMessage;
    if (extendedMessage != null)
    {
        //process
    }
