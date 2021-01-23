    public class MessagesResponse
    {
        public Message[] Messages { get; set; }
    }
    public class Message
    {
        public string Content { get; set; }
        public string SenderId { get; set; }
        public int[] NotifiedUserIds { get; set; }
    }
    public class SimplifiedMessage
    {
        public string Content { get; set; }
        public string SenderId { get; set; }
        public string FromIDs { get; set; }
    }
    static void Main(string[] args)
        {
            SimplifiedMessage[] simplifiedMessages = null;
            MessagesResponse response = new  MessagesResponse
            {
                 Messages = new Message[]
                 {
                     new Message
                     {
                          NotifiedUserIds = new[]{1,2,3,},
                          Content = "One"
                     } ,
                     new Message
                     {
                          NotifiedUserIds = new[]{4,5,6},
                          Content = "Two"
                     },
                     new Message
                     {
                         NotifiedUserIds = new[]{7,8,9},
                          Content = "Three"
                     }
                 }
            };
            var map = Mapper.CreateMap<Message, SimplifiedMessage>()
                .ForMember(s => s.Content, m => m.MapFrom<string>(msg => msg.Content))
                .ForMember(s => s.FromIDs , m => m.MapFrom<string>(msg => string.Join(",",msg.NotifiedUserIds)));
            simplifiedMessages = Mapper.Map<Message[],SimplifiedMessage[]>(response.Messages);
       }
