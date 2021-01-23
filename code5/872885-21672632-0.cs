    [ServiceContract]
    interface IExampleService {
        [OperationContract]
        string GetUsername();
    }
    interface IExampleServiceAsync {
        Task<string> GetUserNameAsync();
    }
    class ExampleService : IExampleService {
        public string GetUsername() {
            return System.Threading.Thread.CurrentPrincipal.Name;
        }
    }
    class ExpampleServiceClient : ServiceClient<IExampleService>, IExampleServiceAsync {
        public Task<string> GetUsernameAsync() {
            return Task.Run(() => GetUsername());
        }
        private string GetUsername() {
            using(Security.Impersonation.Impersonate())
            {
                return base.Proxy.GetUsername();
            }
        }
    }
