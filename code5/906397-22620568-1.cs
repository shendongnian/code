    public class AppActivityTimer
	{
		#region Events - OnActive, OnInactive, OnTimePassed
		public event System.Windows.Input.PreProcessInputEventHandler OnActive;
		public event EventHandler OnInactive;
		public event EventHandler OnTimePassed;
		#endregion
		#region TimePassed
		private TimeSpan _timePassed;
		private DispatcherTimer _timePassedTimer;
		#endregion
		#region Inactivity
		public TimeSpan InactivityThreshold { get; private set; }
		private DispatcherTimer _inactivityTimer;
		private Point _inactiveMousePosition = new Point(0, 0);
		private bool _MonitorMousePosition;
		#endregion
		#region Constructor
		/// <summary>
		/// Timers for activity, inactivity and time passed.
		/// </summary>
		/// <param name="timePassedInMS">Time in milliseconds to fire the OnTimePassed event.</param>
		/// <param name="IdleTimeInMS">Time in milliseconds to be idle before firing the OnInactivity event.</param>
		/// <param name="WillMonitorMousePosition">Does a change in mouse position count as activity?</param>
		public AppActivityTimer(int timePassedInMS, int IdleTimeInMS, bool WillMonitorMousePosition)
		{
			_MonitorMousePosition = WillMonitorMousePosition;
			System.Windows.Input.InputManager.Current.PreProcessInput += new System.Windows.Input.PreProcessInputEventHandler(OnActivity);
			// Time Passed Timer
			_timePassedTimer = new DispatcherTimer();
			_timePassed = TimeSpan.FromMilliseconds(timePassedInMS);
			// Start the time passed timer
			_timePassedTimer.Tick += new EventHandler(OnTimePassedHandler);
			_timePassedTimer.Interval = _timePassed;
			_timePassedTimer.IsEnabled = true;
			// Inactivity Timer
			_inactivityTimer = new DispatcherTimer();
			InactivityThreshold = TimeSpan.FromMilliseconds(IdleTimeInMS);
			// Start the inactivity timer
			_inactivityTimer.Tick += new EventHandler(OnInactivity);
			_inactivityTimer.Interval = InactivityThreshold;
			_inactivityTimer.IsEnabled = true;
		}
		#endregion
		#region OnActivity
		void OnActivity(object sender, System.Windows.Input.PreProcessInputEventArgs e)
		{
			System.Windows.Input.InputEventArgs inputEventArgs = e.StagingItem.Input;
			if (inputEventArgs is System.Windows.Input.MouseEventArgs || inputEventArgs is System.Windows.Input.KeyboardEventArgs)
			{
				if (inputEventArgs is System.Windows.Input.MouseEventArgs)
				{
					System.Windows.Input.MouseEventArgs mea = inputEventArgs as System.Windows.Input.MouseEventArgs;
					// no button is pressed and the position is still the same as the application became inactive
					if (mea.LeftButton == System.Windows.Input.MouseButtonState.Released &&
						mea.RightButton == System.Windows.Input.MouseButtonState.Released &&
						mea.MiddleButton == System.Windows.Input.MouseButtonState.Released &&
						mea.XButton1 == System.Windows.Input.MouseButtonState.Released &&
						mea.XButton2 == System.Windows.Input.MouseButtonState.Released &&
						(_MonitorMousePosition == false ||
							(_MonitorMousePosition == true && _inactiveMousePosition == mea.GetPosition(Application.Current.MainWindow)))
						)
						return;
				}
				// Reset idle timer
				_inactivityTimer.IsEnabled = false;
				_inactivityTimer.IsEnabled = true;
				_inactivityTimer.Stop();
				_inactivityTimer.Start();
				if (OnActive != null)
					OnActive(sender, e);
			}
		}
		#endregion
		#region OnInactivity
		void OnInactivity(object sender, EventArgs e)
		{
			// Fires when app has gone idle
			_inactiveMousePosition = System.Windows.Input.Mouse.GetPosition(Application.Current.MainWindow);
			_inactivityTimer.Stop();
			if (OnInactive != null)
				OnInactive(sender, e);
		}
		#endregion
		#region OnTimePassedHandler
		void OnTimePassedHandler(object sender, EventArgs e)
		{
			if (OnTimePassed != null)
				OnTimePassed(sender, e);
		}
		#endregion
	}
