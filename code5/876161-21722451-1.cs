     public class Collection<T> : IList<T>, ICollection<T>, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
    {
        // Summary:
        //     Initializes a new instance of the System.Collections.ObjectModel.Collection<T>
        //     class that is empty.
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public Collection();
        //
        // Summary:
        //     Initializes a new instance of the System.Collections.ObjectModel.Collection<T>
        //     class as a wrapper for the specified list.
        //
        // Parameters:
        //   list:
        //     The list that is wrapped by the new collection.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     list is null.
        public Collection(IList<T> list);
        // Summary:
        //     Gets the number of elements actually contained in the System.Collections.ObjectModel.Collection<T>.
        //
        // Returns:
        //     The number of elements actually contained in the                           ****System.Collections.ObjectModel.Collection<T>.
        public int Count { get; }****
        //
        // Summary:
        //     Gets a System.Collections.Generic.IList<T> wrapper around the System.Collections.ObjectModel.Collection<T>.
        //
        // Returns:
        //     A System.Collections.Generic.IList<T> wrapper around the System.Collections.ObjectModel.Collection<T>.
        protected IList<T> Items { get; }
