    public interface IImmutable
    {
        // this space intentionally left blank, except for this comment
    }
    public class Datum<T> : IReadOnlyList<T> where T : IImmutable
