    public interface IChangeRequestFormField
    {
        bool IsRequired { get; }
        string OriginalValueString { get; }
        bool ValueHasChanged { get; }
    }
    public class ChangeRequestFormField<T> : IChangeRequestFormField
    {
        // ...
    }
