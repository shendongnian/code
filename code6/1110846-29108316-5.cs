    public interface ITranslator
    {
        Type SourceType { get; }
        Type DestinationType { get; }
        TDest Translate<TSource, TDest>(TSource toTranslate);
    }
    public static class ITranslatorExtensions
    {
        public static bool AppliesTo(this ITranslator translator, Type sourceType, Type destinationType)
        {
            return (translator.SourceType.Equals(sourceType) && translator.DestinationType.Equals(destinationType));
        }
    }
