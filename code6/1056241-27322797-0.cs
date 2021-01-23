    public class Datum<T> : IReadOnlyList<T>
    {
        private IList<string> objects;
        public T this[int i] {
            get { return JsonConvert.DeserializeObject<T>(objects[i]); }
            private set { this.objects[i] = JsonConvert.SerializeObject(value); }
        }
        public Datum(IList<T> obj) {
            this.objects = new List<string>();
            foreach (T t in obj) {
                this.objects.Add(JsonConvert.SerializeObject(t));
            }
            this.Count = obj.Count;
        }
        public IEnumerator<T> GetEnumerator() {
            return this.objects.Select(JsonConvert.DeserializeObject<T>).GetEnumerator();
        }
    }
