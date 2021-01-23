    public interface ITextValue
    {
        string GetValue();
        string GetText();
    }
    // for each entity
    public partial class SomeEntity : ITextValue // this for each EF-type
    {
        public GetValue() { return this.ID.ToString(); }
        public GetValue() { return this.Name; }
    }
