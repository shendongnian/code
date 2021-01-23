    class Service : IService, ISuperUser
    {
        void GetSquaredAsync(double x)
        {
            callback = OperationContext.Current.GetCallbackChannel<IClientCallBack>();
            callback.Result(x * x);
        }
        public string WhoIsSpecial(string name)
        {
            return String.Format("{0} is special ^_^", name);
        }
    }
