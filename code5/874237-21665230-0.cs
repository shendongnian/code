    public class PrivateMessageHeader {
        public PrivateMessageHeader() { Messages = new List<PrivateMessageDetail>; }
        public int PrivateMessageHeaderId {get;set;}
        public DateTime ThreadTime {get;set;} // Date of the start of thread
        public string User1 {get;set;}
        public string User2 {get;set;}  // this could be made to a list to allow multiples
        public ICollection<PrivateMessageDetail> Messages {get;set;}
    }
    public class PrivateMessageDetail {
        public int PrivateMessageDetailId {get;set;}
        public DateTime MessageDate {get;set;}
        public string FromUser {get;set;} // Don't need ToUser, it's already in header
        public string Message {get;set;}
        public PrivateMessageHeader parent {get;set;}
    }
