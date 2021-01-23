	public interface IFriendable<T>
	{
		void accept(T friend);
	}
	public interface IFriendship<T>
	{
		void engage(T friend);
	}
	public class ChosenOne : IFriendable<InControl>
	{
		private InControl _friend { get; set; }
		private ChosenOne()
		{
			InControl.friendship.engage(this);
		}
		public void accept(InControl friend)
		{
			_friend = friend;
		}
	}
	public class ChosenTwo : IFriendable<InControl>
	{
		private InControl _friend { get; set; }
		private ChosenTwo()
		{
			InControl.friendship.engage(this);
		}
		public void accept(InControl friend)
		{
			_friend = friend;
		}
	}
	public class InControl
	{
		public interface IFriendship : IFriendship<ChosenOne>, IFriendship<ChosenTwo> { }
		public static IFriendship friendship { get { return Friendship.instance; } }
		private class Friendship : IFriendship
		{
			static Friendship()
			{
			}
			internal static readonly Friendship instance = new Friendship();
			public void engage(ChosenOne friend)
			{
				friend.accept(new InControl());
			}
			public void engage(ChosenTwo friend)
			{
				friend.accept(new InControl());
			}
		}
		private InControl()
		{
		}
	}
