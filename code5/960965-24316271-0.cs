	public class SomeRequestHandler {
		readonly IBus bus;
		public SomeRequestHandler(IBus bus) {
			this.bus = bus;
		}
		public void Handle(SomeRequest request) {
			bus.Reply(new SomeReply(...));
		}
	}
