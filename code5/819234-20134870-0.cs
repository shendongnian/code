    public static class TimeSpanExtension
    {
        public static TimeSpan TryParseTenth(string timeSpanString)
        {
            //change following line to accomodate date format if needed
            timeSpanString += "0";
            TimeSpan ts = new TimeSpan();
            if (TimeSpan.TryParse(timeSpanString, out ts))
            {
                // recalculate from tenth of minute into seconds
                float realSeconds = ts.Seconds * 60 / 100;
                
                //final operation to correct
                return ts.Subtract(new TimeSpan(0, 0, ts.Seconds - (int)realSeconds));
            }
            else
                return TimeSpan.Zero;
        }
    }
