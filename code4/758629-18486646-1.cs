    public class FooViewModel : Screen
    {
        private IService service;
        public FooViewModel(IService service)
        {
            this.service = service;
        }
        public void Load(bool runAync = true)
        {
            if (runAync)
                Task.Factory.StartNew(() => service.GetResult())
                    .ContinueWith(t => SetResults(t.Result));
            else SetResults(service.GetResult());
        }
        private void SetResults(Result result)
        {
            //Fill collections and so on 
        }
    }
