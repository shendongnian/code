    var bus = RabbitHutch.CreateBus("host=localhost")
    while((input = Console.ReadLine()) != "q") {
      for(int i = 1; i < 2; i++) {
        var message = new Message<TextMessage>(new TextMessage {
         Text = input + i
        });
        bus.Publish(message);
        }
     }
