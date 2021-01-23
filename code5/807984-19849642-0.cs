    public class PlayerSpeedChangedMessage {
        public Guid PlayerId { get; set; }
        public int OldSpeed { get; set; }
        public int NewSpeed { get; set; }
    }
    public class MyMessageHandler {
        
        public MyMessageHandler() {
            Messenger<PlayerSpeedChangedMessage>.Subscribe(OnDead);
        }
        HandleSpeedChange(PlayerSpeedChangedMessage message) {
            // Do stuff with the message
        }
    }
