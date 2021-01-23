    public static void WaitForCondition(Func<bool> predict)
		{
			Task.Delay(TimeSpan.FromMilliseconds(1000)).ContinueWith(_ =>
			{
				var result = predict();
				// the condition result is false, and we need to wait again.
				if (result == false)
				{
					WaitForCondition(predict);
				}
			});
		}
