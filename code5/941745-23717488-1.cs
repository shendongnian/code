    // Custom controller
    public class MyController : XSocketController
    {
        public int Age { get; set; }
        public override void OnMessage(ITextArgs textArgs) {
            this.SendToAll(textArgs);
        }
    }
    // then in the client
    someXSocketClient.SetServerProperty("Age", 15);
    int age = Convert.ToInt32(someXSocketClient.GetServerProperty("Age"));
