    namespace WcfService1
    {
    
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            List<RecommendPlace> getSearchCoords(string search);
        }
    }
