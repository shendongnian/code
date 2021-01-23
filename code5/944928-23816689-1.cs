    var result = people.AsQueryable<Person>().Where(
        person => person.Dates.Any(date => 
            date.Value > beginRange && date.Value < endRange));
.
    public class DocumentWrapper<T>
    {
        public ObjectId Id { get; private set; }
        public T Value { get; private set; }
        
        public DocumentWrapper(T value)
        {
            Id = ObjectId.GenerateNewId();
            Value = value;
        }
    }
