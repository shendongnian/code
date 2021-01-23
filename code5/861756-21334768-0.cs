	class WorkingClass
	{
		public void Work()
		{
			//Works fine
			((Action)DoSomething).RunAsThread();
			//Works fine
			Extensions.RunAsThread(DoSomething);
			//But I really need this to work
			DoSomething.RunAsThread();
		}
		private Action DoSomething = () =>
		{
			//Do Something
		};
	}
