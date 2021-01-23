    public interface IMyService
    {
        [OperationContract]
        [FaultContract(typeof(Message))]
        void WCFOperation();
    }
 
    [DataContract(Namespace = "http://www.mycompany.pt/myservice")]
    public class Message
    {
        String _code;
        [DataMember]
        public String Code
        {
            get { return _code; }
            set { _code = value; }
        }
        String _text;
        [DataMember]
        public String Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
