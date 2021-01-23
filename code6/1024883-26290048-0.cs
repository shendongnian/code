        public IEnumerable<T> GetNotMatchingElements<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            var combinedCollection = collection1.Union(collection2);
            var filteredCollection = combinedCollection.Except(collection1.Intersect(collection2));
            return filteredCollection;
        }
