    public interface ITextValue
    {
        string GetValue(object obj);
        string GetText(object obj);
    }
    // for each entity
    public class SomeEntityReader : ITextValue // this for each EF-type
    {
        public GetValue(object obj) { return ((SomeEntity).ID).ToString(); }
        public GetValue(object obj) { return ((SomeEntity)this).Name; }
    }
    // somewhere central
    var Readers = new Dictionary<Type,ITextValue>()
    Readers.Add(typeof(SomeEntity), new SomeEntityReader());
    // etc
