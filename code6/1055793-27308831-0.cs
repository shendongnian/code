    public enum CollectionRange
    {
        One,
        ZeroToOne,
        ZeroToMany,
        OneToMany
    }
    public interface ICollectableTypeTemplate
    {
        CollectionRange PossibleRange { get; }
    }
    public static class MyExtentions
    {
        public static bool MustHaveAtleastOneItem(this ICollectableTypeTemplate i)
        {
            return i.PossibleRange == CollectionRange.One ||
                       i.PossibleRange == CollectionRange.OneToMany;
        }
        public static bool MulipleOfTypeAllowed(this ICollectableTypeTemplate i)
        {
            return i.PossibleRange == CollectionRange.ZeroToMany ||
                      i.PossibleRange == CollectionRange.OneToMany;
        }
        
    }
