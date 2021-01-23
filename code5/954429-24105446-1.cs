	internal static class Locker
	{
		private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		// We join or lockers into one field, because boolean cann't be handled by Interlocked routines.
		private static volatile int _Lockers = 0;
		// Thread-safe update routine
        internal static void AtomicUpdate(int mask, bool value)
        {
            SpinWait sw = new SpinWait();
            do
            {
                int old = _Lockers;
                if (Interlocked.CompareExchange(ref _Lockers, value ? old | mask : old &~mask, old) == old)
                {
                    return;
                }
                sw.SpinOnce();
            } while (true);
        }
		// Reason 1 will be the first bit of _Lockers field, Reason 2 - the second and so on.
        internal static bool LockedByReason1
        {
            get
            {
                return (_Lockers & 1) > 0;
            }
            set
            {
                Locker.AtomicUpdate(1, value);
            }
        }
        internal static bool LockedByReason2
        {
            get
            {
                return (_Lockers & 2) > 0;
            }
            set
            {
                Locker.AtomicUpdate(2, value);
            }
        }
        internal static bool LockedByReason3
        {
            get
            {
                return (_Lockers & 4) > 0;
            }
            set
            {
                Locker.AtomicUpdate(4, value);
            }
        }
		internal static bool Locked
		{
			get
			{
				log.DebugFormat("LockedByReason1: {0}, LockedByReason2: {1}, LockedByReason3: {2}", LockedByReason1, LockedByReason2, LockedByReason3);
				return _Lockers > 0;
			}
		}
	}
