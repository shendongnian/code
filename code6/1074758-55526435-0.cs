      public static class StopwatchExtensions
      {
        /// <summary>
        /// Support for .NET Framework <= 3.5
        /// </summary>
        /// <param name="sw"></param>
        public static void Restart(this Stopwatch sw)
        {
          sw.Stop();
          sw.Reset();
          sw.Start();
        }
      }
