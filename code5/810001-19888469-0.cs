	class Program
	{
		static void Main(string[] args)
		{
			IMessageBus messageBus = null;
			messageBus
				.Event<CorrectorAdded>()
				.Subscribe(eventArgs => { /*skipped*/ });
			//skipped
			messageBus
				.Event<CorrectorAdded>()
				.Publish(new CorrectorAddedArgs(1));
		}
	}
	public abstract class EventBase
	{
		//skipped
	}
	public abstract class EventBase<TPayload> : EventBase
	{
		public IDisposable Subscribe(Action<TPayload> listener)
		{
			//skipped
		}
		public void Publish(TPayload payload)
		{
			//skipped
		}
	}
	
	public class CorrectorAdded : EventBase<CorrectorAddedArgs>
	{
	}
	public class CorrectorAddedArgs
	{
		public int CorrectorId { get; private set; }
		public CorrectorAddedArgs(int correctorId)
		{
			CorrectorId = correctorId;
		}
	}
	public interface IMessageBus
	{
		TEvent Event<TEvent>() where TEvent : EventBase, new();
	}
