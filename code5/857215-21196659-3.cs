            public class MovieCollection : List<Movie>, IHierarchicalEnumerable
            {
    
                public IHierarchyData GetHierarchyData(object enumeratedItem)
                {
                    return enumeratedItem as IHierarchyData;
                }
    
                public System.Collections.IEnumerator GetEnumerator()
                {
                    throw new NotImplementedException();
                }
            }
