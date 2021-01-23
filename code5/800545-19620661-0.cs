    public interface IQueryPartDescriptor
    {
        /// <summary>
        /// Converts the specified object into a string usable as query part.
        /// </summary>
        string ObjectToQueryPart(string prefix, object obj);
        /// <summary>
        /// Describes the properties containing lists of children objects.
        /// </summary>
        IEnumerable<ChildrenCollectionDescriptor> ChildrenListsDescriptors { get; }
    }
