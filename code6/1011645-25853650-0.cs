    public interface IOperation
    {
        Type InputType { get; }
        Type OutputType { get; }
        object GetOutput(object input);
    }
