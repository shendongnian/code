    [ServiceContract]
    public interface IMyTestServce
    {
        [OperationContract]
        [WebInvoke(Method = "POST", 
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "/Upload?author={author}&pages={pages}&size={size}&name={name}&authToken={authToken}")]
        void Upload(string author, int pages, long size, string name, 
                    string authToken, 
                    Stream file);
    }
    public class MyTestService : IMyTestServce
    {
        public void Upload(string author, int pages, long size, string name, 
                           string authToken, 
                           Stream file)
        {
            Console.WriteLine(String.Format("author={0}&pages={1}&size={2}&name={3}&authToken={4}", author, pages, size, name, authToken));
            Console.WriteLine(new StreamReader(file).ReadToEnd());
        }
    }
