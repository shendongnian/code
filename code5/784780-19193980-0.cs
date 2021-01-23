    public interface IRequest<T>
    {
        T GetResponse();
    }
    public interface IResponse<T>
    {
        T GetData();
    }
    public class MyRequest : IRequest<MyResponse>
    {
        public MyResponse GetResponse()
        {
            return new MyResponse();
        }
    }
    public class MyResponse : IResponse<MyData>
    {
        public MyData GetData()
        {
            return new MyData() { Name = "Test" };
        }
    }
    public class MyData
    {
        public string Name { get; set; }
    }
