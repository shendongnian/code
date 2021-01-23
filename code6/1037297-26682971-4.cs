    [Serializable]
    [JsonObject]
    public class ListContainer<T> : IList<T>
    {
        [JsonIgnore]
        readonly List<T> _list = new List<T>();
        [JsonProperty("List")]
        private T [] SerializableList
        {
            get
            {
                return _list.ToArray();
            }
            set
            {
                _list.Clear();
                foreach (var item in value)
                    Add(item);
            }
        }
        [JsonIgnore]
        public int Count
        {
            get { return _list.Count; }
        }
        [JsonIgnore]
        public bool IsReadOnly
        {
            get { return ((IList<T>)_list).IsReadOnly; }
        }
        // Everything beyond here is boilerplate.
    }
