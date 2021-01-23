        [MessageContract]
        public class Record
        {
          [MessageHeader(Name="ID")] public int personID;
          [MessageBodyMember(Order=1)] public string comments;
        }
