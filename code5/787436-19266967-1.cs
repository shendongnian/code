		public static Task BeginAsync(this Storyboard storyboard)
		{
			return EventToTaskAsync<object>(
					e => { storyboard.Completed += e; storyboard.Begin(); },
					e => storyboard.Completed -= e);
		}
