    public class SomeJsonObject
    {
        public String id { get; set; }
        public String name { get; set; }
        public String type { get; set; }
        public bool isInput { get; set; }
        public String value { get; set; }
        public List<SomeJsonObject> items { get; set; }
        public IEnumerable<SomeJsonObject> AllWithChildren
        {
            get
            {
                yield return this;
                if (this.items == null) yield break;
                foreach (var descendant in
                   this.items.SelectMany(child => child.AllWithChildren))
                {
                    yield return descendant;
                }
            }
        }
    }
