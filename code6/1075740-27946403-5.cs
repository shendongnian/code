    public static class EorzeaDateTimeExtention
    {
        public static DateTime ToEorzeaTime(this DateTime date)
        {
            const double EORZEA_MULTIPLIER = 3600D/175D;
    
            long epochTicks = date.ToUniversalTime().Ticks - (new DateTime(1970, 1, 1).Ticks);
                           
            long eorzeaTicks = (long)Math.Round(epochTicks * EORZEA_MULTIPLIER);
    
            return new DateTime(eorzeaTicks);
        }
    }
