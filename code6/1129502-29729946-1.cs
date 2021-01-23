    public interface IFoo
    {
        object Data { get; }
        object GetData(object data);
    }
    public interface INewFoo : IFoo
    {
        new string Data { get; }
        new string GetData(string data);
    }
    public class Foo : INewFoo
    {
        object IFoo.Data { get { return Data; } }
        object IFoo.GetData(object data) { return data; }
        public string Data { get; set; }
        public string GetData(string data) { return data; }
    }
