		/// <summary>
		/// Accepts a pending connection request.
		/// </summary>
		/// <param name="tcpListener"></param>
		/// <param name="timeout"></param>
		/// <param name="pollInterval"></param>
		/// <exception cref="System.InvalidOperationException"></exception>
		/// <exception cref="System.TimeoutException"></exception>
		/// <returns></returns>
		public static Socket AcceptSocket(this TcpListener tcpListener, TimeSpan timeout, int pollInterval=10)
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();
			while (stopWatch.Elapsed < timeout)
			{
				if (tcpListener.Pending())
					return tcpListener.AcceptSocket();
				Thread.Sleep(pollInterval);
			}
			throw new TimeoutException();
		}
