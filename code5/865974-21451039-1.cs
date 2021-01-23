    public class MyNewService : INewService
    {
        private readonly V1.MyService v1service = new V1.MyService();
        public int SomeMethod()
        {
            return this.v1service.SomeMethod();
        }
    }
