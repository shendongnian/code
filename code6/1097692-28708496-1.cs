    class BotNavigation
    {
		private EventLoopScheduler _eventLoop = new EventLoopScheduler();
		
		private void Take(string message, int distanceTime, SerialPort port)
		{
			Observable
				.Interval(TimeSpan.FromMilliseconds(250.0))
				.Select(x => message)
				.StartWith(message)
				.Take(distanceTime)
				.ObserveOn(_eventLoop)
				.Subscribe(port.WriteLine);
		}
		
        public void TakeForward(int distanceTime, SerialPort port)
        {
			this.Take("F", distanceTime, port);
        }
		
		public void TakeBackward(int distanceTime, SerialPort port)
        {
			this.Take("B", distanceTime, port);
        }
		
		public void TurnLeft(int distanceTime, SerialPort port)
        {
			this.Take("L", distanceTime, port);
        }
		
		public void TurnRight(int distanceTime, SerialPort port)
        {
			this.Take("R", distanceTime, port);
        }
    }
