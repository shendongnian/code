    [__DynamicallyInvokable]
        public static DateTime Now
        {
          [__DynamicallyInvokable] get
          {
            DateTime utcNow = DateTime.UtcNow;
            bool isAmbiguousLocalDst = false;
            long ticks1 = TimeZoneInfo.GetDateTimeNowUtcOffsetFromUtc(utcNow, out isAmbiguousLocalDst).Ticks;
            long ticks2 = utcNow.Ticks + ticks1;
            if (ticks2 > 3155378975999999999L)
              return new DateTime(3155378975999999999L, DateTimeKind.Local);
            if (ticks2 < 0L)
              return new DateTime(0L, DateTimeKind.Local);
            else
              return new DateTime(ticks2, DateTimeKind.Local, isAmbiguousLocalDst);
          }
        }
