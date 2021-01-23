    public abstract class StatementViewModel
    {
        public abstract StatementType StatementType { get; }
        ...
    }
    public enum StatementType
    {
        Relief,
        RequestForSalary,
        ...
    }
