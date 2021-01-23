   	class CallingClass
	{
		private ClassWithEvent m_classwithevent;
		public CallingClass()
		{
			m_classwithevent = new ClassWithEvent();
			m_classwithevent.FinishedEventHandler += OnFinished;
		}
		public void Foo()
		{
			m_classwithevent.DoStuff();
		}
		void OnFinished(string sText)
		{
			Console.WriteLine("Message received:" + sText);
		}
	}
	class ClassWithEvent
	{
		public delegate void FinishedDelegate(string sText);
		public event FinishedDelegate FinishedEventHandler;
		public void DoStuff()
		{
			for (int i = 0; i < 1000; i++)
			{
				// Do some useful work
			}
			if (FinishedEventHandler != null)
				FinishedEventHandler("DoStuff has finished");
		}
	}
