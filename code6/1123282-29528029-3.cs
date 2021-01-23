    public interface IApt
    {
        DateTime Start { set;get; }
        int Length { set;get; }
        string Description{ set;get; }
        bool Occurs(DateTime date);
    }
