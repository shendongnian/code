    [ServiceContract]
    public interface IService {
      [OperationContract]
      void DoWork();
    }
    
    public class Service : IService {
        public void DoWork() {
            throw new Exception("No Application_Error for me, please.");
        }
    }
    protected void Page_Load(object sender, EventArgs e) {
      new Thread(() => {
        throw new Exception("No Application_Error for me, either.");
      }).Start();
    }
