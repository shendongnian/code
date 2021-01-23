     [ServiceContract]
        public interface IChatEngine
        {
            [OperationContract]
            ChatEngine.JoinChatRoomResult JoinChatRoom(string chatRoomId, string href);
    
            [OperationContract]
            void LeaveChatRoom(string chatRoomId, string token, string messengerTargetUserId);
    
            [OperationContract]
            ChatEngine.EventsResult GetEvents(string chatRoomId, string token, long fromTimestamp, string messengerTargetUserId);
    
            [OperationContract]
            ChatEngine.SendMessageResult SendMessage(string chatRoomId, string token, string toUserId, string message, 
                                                          bool bold = false, bool italic = false, bool underline = false, string fontName = null, int? fontSize = null,
                                                          string color = null);
    
            [OperationContract]
            ChatEngine.SendMessageResult SendCommand(string chatRoomId, string token, string targetUserId, string command);
    
            [OperationContract]
            string BroadcastVideo(string prevGuid, string token, int chatRoomId, string targetUserId);
    
            [OperationContract]
            void StopVideoBroadcast(string token, int chatRoomId);
    
            void StopVideoBroadcast(string userId, string chatRoomId);
        }
    
       
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        public class ChatEngine : IChatEngine
        {
            private static IChatRoomProvider chatRoomProvider;
            private static IChatRoomStorage chatRoomStorage;
            private static IChatUserProvider chatUserProvider;
            private static IChatSettings chatSettingsProvider;
            private static IMessengerPresenceProvider messengerProvider;
    
            private static bool importsSatisfied = false;
    
            public ChatEngine()
            {
                   // here goes constructor
            }    
           
            public JoinChatRoomResult JoinChatRoom(string chatRoomId, string href)
            {
               //here goes method JoinChatRoom
               // note it doesn't have [OperationContract] attribute
               return result;
            }
    
            
            public void LeaveChatRoom(string chatRoomId, string token, string messengerTargetUserId)
            {
                //here goes LeaveChatRoom. Note it doesn't have [OperationContract] attribute
            }
    .//etc
    .
    .
    }
