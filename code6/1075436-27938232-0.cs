    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,BodyStyle=WebMessageBodyStyle.WrappedResponse)]
        List<RequestData> GetUser(Request data);
        
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "UsersList/{id}",RequestFormat=WebMessageFormat.Json)]
        RequestData UsersList(string id);
        
        
    }
    public class DataService : IDataService
    {
        public List<RequestData> GetUser(Request data)
        {
            List<RequestData> list = new List<RequestData>();
            if (data.Name.ToUpper() == "MAIRAJ")
            {
                list.Add(new RequestData
                {
                    Name = "Mairaj",
                    Age = 25,
                    Address = "Test Address"
                });
                list.Add(new RequestData
                {
                    Name = "Ahmad",
                    Age = 25,
                    Address = "Test Address"
                });
                list.Add(new RequestData
                {
                    Name = "Minhas",
                    Age = 25,
                    Address = "Test Address"
                });
            }
            return list;
        }
        public RequestData UsersList(string userId)
        {
            if (userId == "1")
            {
                return new RequestData
                {
                    Name = "Mairaj",
                    Age = 25,
                    Address = "Test Address"
                };
            }
            else
            {
                return new RequestData
                {
                    Name = "Amir",
                    Age = 25,
                    Address = "Test Address"
                };
            }
        }
        
    }
