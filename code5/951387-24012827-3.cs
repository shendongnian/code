	public static class SomeManager {
		private static Timer gAppTimer;
		private static object lockObject = new object();
		public static void StartTimer() {
			if (gAppTimer == null) {
				lock (lockObject) {
					if (gAppTimer == null) {
						gAppTimer = new Timer(OnTimerTick, null, 60 * 1000, 60 * 1000);
					}
				}
			}
		}
		public static void StopTimer() {
			if (gAppTimer != null) {
				lock (lockObject) {
					if (gAppTimer != null) {
						gAppTimer.Change(Timeout.Infinite, Timeout.Infinite);
						gAppTimer = null;
					}
				}
			}
		}
		private static void OnTimerTick(object state) {
			Action();
		}
		public static void Action() {
			// Do what you need to do
		}
	}
