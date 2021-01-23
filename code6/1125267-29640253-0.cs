	public abstract class Actor<T> : Visual<T> where T : ActorDescription
	{
		#region Events
		/// <summary>
		/// Event occurs when the actor is dead
		/// </summary>
		public event Action<Actor<T>> Dead;
		#endregion
		
		...
		
		private void SomeFunc()
		{
			if (Dead != null)
				Dead();
		}
	}
