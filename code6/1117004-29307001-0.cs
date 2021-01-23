            public class SampleObject
            {
                public string Id { get; set; }
                public string Next { get; set; }
            }
            public List<SampleObject> Sort(List<SampleObject> collection)
            {
                var sortedCollection = new List<SampleObject>();
    
                foreach (var item in collection)
                {
                    var next = collection.FirstOrDefault(x => x.Id.Equals(item.Next));
    
                    if (next != null && !sortedCollection.Contains(next) && !sortedCollection.Contains(item))
                    {
                        sortedCollection.Add(item);
                        sortedCollection.Add(next);
                    }
                }
    
                return sortedCollection;
            }
