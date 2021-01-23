    public class FooViewModel : Screen
    {
        private IService service;
        public FooViewModel(IService service)
        {
            this.service = service;
        }
        public void Load()
        {
            Task.Factory.StartNew(() => service.GetResult())
                .ContinueWith(t =>
                    {
                        //Fill collections and so on
                    });
        }
    }
    public interface IService
    {
        Result GetResult();
    }
