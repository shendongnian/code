    [ComplexType]
    public class DateTimeCollection : Collection<DateTime>
    {
        public void AddRange(IEnumerable<DateTime> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        [Column("Times")]
        public string Serialized
        {
            get { return JsonConvert.SerializeObject(this); }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Clear();
                    return;
                }
                var items = JsonConvert.DeserializeObject<DateTime[]>(value);
                Clear();
                AddRange(items);
            }
        }
    }
