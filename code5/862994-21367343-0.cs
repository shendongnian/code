        public class FactoryResponseImpl : IFactoryResponse
        {
            object IFactoryResponse.instance { get; set; }
            string IFactoryResponse.instanceconfig { get; set; }
        }
