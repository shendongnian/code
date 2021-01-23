        public static bool SameDate( DateTimeOffset first, DateTimeOffset second )
        {
            bool returnValue = false;
            DateTime firstAdjusted = first.UtcDateTime;
            DateTime secondAdjusted = second.UtcDateTime;
            if( firstAdjusted.Date == secondAdjusted.Date )
                returnValue = true;
            return returnValue;
        }
