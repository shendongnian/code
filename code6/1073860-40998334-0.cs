    public static class Hierarchy
    {
        /// <summary>
        /// Gets the collection of leafs (items that have no children) from a hierarchical collection
        /// </summary>
        /// <typeparam name="T">The collection type</typeparam>
        /// <param name="source">The sourceitem of the collection</param>
        /// <param name="getChildren">A method that returns the children of an item</param>
        /// <returns>The collection of leafs</returns>
        public static IEnumerable<T> GetLeafs<T>(T source, Func<T, IEnumerable<T>> getChildren)
        {
            if (!getChildren(source).Any())
            {
                yield return source;
            }
            else
            {
                foreach (var child in getChildren(source))
                {
                    foreach (var subchild in GetLeafs(child, getChildren))
                    {
                        yield return subchild;
                    }
                }
            }
        }
    }
