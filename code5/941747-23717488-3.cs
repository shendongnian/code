    // Custom controller
    public class MyController : XSocketController
    {
        public int Age { get; set; }
        public override void OnMessage(ITextArgs textArgs) {
            this.SendToAll(textArgs);
        }
    }
    // then in the client
    var client = new XSocketClientEx("ws://127.0.0.1:4502/MyController", "*");
    client.WaitForConnection(); // waits efficiently for client.IsConnected == true
    client.SetServerProperty("Age", 15);
    int age = Convert.ToInt32(client.GetServerProperty("Age"));
