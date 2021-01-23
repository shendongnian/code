    interface ILoginImplementation
    {
        public void SetInitialUserName(string name);
    }
    interface ILoginLogic
    {
        public bool TryAuthenticate(string name, string password);
    }
