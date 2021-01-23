    namespace GenerateMillionTags
    {
    class Program
    {
        static void Main(string[] args)
        {
            var list = Message1.CreateMessages(10000);
            // Do whatever you want with the list.
        }
    }
    public class Message1
    {
        public string fld1_ { get; set; }
        public string fld2_ { get; set; }
        public string fld3_ { get; set; }
        public string fld4_ { get; set; }
        public string fld5_ { get; set; }
        public Message1()
        {
            fld1_ = @"20140227";
            fld2_ = @"ABCD";
            fld3_ = @"BUICK";
        }
        public Message1(string fld1, string fld2, string fld3)
        {
            fld1_ = fld1;
            fld2_ = fld2;
            fld3_ = fld3;
        }
        public static List<Message1> CreateMessages(uint count)
        {
            var messageList = new List<Message1>();
            for (int i = 0; i < count; i++)
            {
                // here ids can be made/formatted as sophisticately as you want.
                messageList.Add(new Message1() {fld4_ = "ID" + i, fld5_ = "REG" + i});
            }
            return messageList;
        }
    }
    }
