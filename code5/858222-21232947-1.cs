    public class MockTransactionalCommandHandler : 
        ITransactionalCommandHandler<CommandStub, ResultStub> {
        public ResultStub Result { get { throw new NotImplementedException(); } }
        public void Handle(CommandStub command) { }
    }
