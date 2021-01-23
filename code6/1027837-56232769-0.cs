	public static class DispatcherExtensions {
		public static int clearInterval = 10_000;
		private static long time => DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
		private static long lastClearTime = time;
		private static Dictionary<int, DispatcherOperation> currOperations = new Dictionary<int, DispatcherOperation>();
		private static object sync = new object();
		public static void invokeLastAsync(this Dispatcher d,  Action a, DispatcherPriority p = DispatcherPriority.Background, [CallerFilePath]object key1 = null, [CallerLineNumber]object key2 = null) {
			lock (sync) {
				DispatcherOperation dop;
				var k = key1.GetHashCode() ^ key2.GetHashCode();
				if (currOperations.ContainsKey(k)) {
					dop = currOperations[k];
					currOperations.Remove(k);
					dop.Abort();
				}
				dop = d.BeginInvoke(a, p);
				clearOperations(false);
				currOperations.Add(k, dop);
			}
		}
		public static void clearOperations(bool force = true) {
			var ct = time;
			if (!force && ct - lastClearTime < clearInterval) return;
			var nd = new Dictionary<int, DispatcherOperation>();
			foreach (var ao in currOperations) {
				var s = ao.Value.Status;
				if (s == DispatcherOperationStatus.Completed
					|| s == DispatcherOperationStatus.Aborted)
				nd.Add(ao.Key, ao.Value);
			}
			currOperations = nd;
			lastClearTime = ct;
		}
	}
