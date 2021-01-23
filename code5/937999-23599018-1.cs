	public abstract class AbstractClass
	{
		public void PerformThisFunction()
		{
			MustBeCalled();
			AbstractMethod();
		}
		private void MustBeCalled()
		{
			
		}
		protected virtual void AbstractMethod()
		{
			MustBeCalled();
		}
	}
