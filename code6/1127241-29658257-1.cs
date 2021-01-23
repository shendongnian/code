    [Flags]
    public enum OperationComponents
    {
        TextFormatting = 1,
        SpellChecking = 2,
        Translation = 4
    }
    
    public class TextProcessingParameters
    {
        public IEnumerable<OperationComponents> Operations { get; set; }
        // other parameters, including parameters for different operations
    }
    
