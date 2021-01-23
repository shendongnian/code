    public interface IFactoryResponse
            {
                object instance { get; set; }
                string instanceconfig { get; set; }
            }
        
            public class FactoryResponseImpl : IFactoryResponse
            {
                object IFactoryResponse.instance { get; set; }
                string IFactoryResponse.instanceconfig { get; set; }
            }
        
            class Test
            {
                public void TestMethod()
                {
        
                    IFactoryResponse response = new FactoryResponseImpl();
                    response.instance = null;
                } 
            }
