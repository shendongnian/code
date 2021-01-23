    public class Main
    {
        private ClientBase _clientBase;
        public Main(ClientBase clientBase)
        {
            _clientBase = clientBase;
        }
        public void SomeMethod()
        {
            // Use ClientBase.FUNCTION here
            _clientBase.FUNCTION();
        }
    }
