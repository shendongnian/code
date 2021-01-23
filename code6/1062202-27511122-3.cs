	public interface IConsumer<in IMessage>
	{
		object Process (IMessage m);
	}
	public class Mop1 : IConsumer<Message1>
	{
		public object Process (Message1 msg)
		{
			return null;
		}
	}
