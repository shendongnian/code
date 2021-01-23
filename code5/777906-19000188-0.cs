     public interface IWCF
    {
        [OperationContract]
        bool method1();
    
        [OperationContract]
        bool method2();
    }
    
    public class WCF:  IWCF
    {
        private connection connectionHandler;
    
        public WCF(Iconnection con)
        {
             if(con != null){
                connectionHandler = con;
            } else {
                connectionHandler = takedefault;
            }
        }
    
        public bool method1(){
        ...
        }
    
        public bool method2(){
        ...
        }
    
       
       
    }
