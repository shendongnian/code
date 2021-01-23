    public class AsyncAwaitActor : ReceiveActor
    {
        public AsyncAwaitActor()
        {
            Receive<string>(async m =>
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Sender.Tell("done");
            });
        }
    }
    public class AskerActor : ReceiveActor
    {
        public AskerActor(ActorRef other)
        {
            Receive<string>(async m =>
            {
                var res = await other.Ask(m);
                Sender.Tell(res);
            });
        }
    }
    public class ActorAsyncAwaitSpec : AkkaSpec
    {
        [Fact]
        public async Task Actors_should_be_able_to_async_await_ask_message_loop()
        {
            var actor = Sys.ActorOf(Props.Create<AsyncAwaitActor>()
            .WithDispatcher("akka.actor.task-dispatcher"),
                "Worker");
            //IMPORTANT: you must use the akka.actor.task-dispatcher
            //otherwise async await is not safe
            var asker = Sys.ActorOf(Props.Create(() => new AskerActor(actor))
            .WithDispatcher("akka.actor.task-dispatcher"),
                "Asker");
            var res = await asker.Ask("something");
            Assert.Equal("done", res);
        }
    }
