    public interface IValidatable
    {
        bool IsValid();
    }
    ...
    public class SomeBoolClass: IValidatable
    {
        private bool Data;
        public bool IsValid()
        {
            return this.Data; // i.e. return Data == true
        }
    }
    ...
    public class SomeStringClass: IValidatable
    {
        private string Data;
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(this.Data);
        }
    }
