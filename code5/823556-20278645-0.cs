    [Test]
        public void whern_reseiving_command_it_sent_to_the_command_bus()
        {
            var rCommand = new DummyCommand() {SomeProp = 2};
            var serializedCommand = JsonConvert.SerializeObject(rCommand);
            
            var envelope = new MessageEnvelope()
            {
                MetaData = new MetaData{MessageType = "DummyCommand", MessageTypeVersion = 1},
                MessageData = serializedCommand
            };
            var fakeCommand = A.Fake<ICommandBus>();
            var fakeCommandFetcher = A.Fake<ICommandFetcher>();
            A.CallTo(()=> fakeCommandFetcher.FetchFrom(A<MessageEnvelope>._)).Returns(rCommand);
            var browser = new Browser(with =>
            {
                with.Module<CommandModule>();
                with.Dependency<ICommandBus>(fakeCommand);
                with.Dependency<ICommandFetcher>(fakeCommandFetcher);
            });
            var result = browser.Post("/", with =>
            {
                with.HttpRequest();
                with.JsonBody(envelope);
            });
            A.CallTo(() => fakeCommand.Send(rCommand,A<MetaData>.That.Matches(m =>m.ContextInfo == envelope.MetaData.ContextInfo && m.MessageType == envelope.MetaData.MessageType))).MustHaveHappened();
