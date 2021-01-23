        static double GetDouble(string s)
        {
            double d;
            var formatinfo = new NumberFormatInfo();
            formatinfo.NumberDecimalSeparator = ".";
            if (double.TryParse(s, NumberStyles.Float, formatinfo, out d))
            {
                return d;
            }
            formatinfo.NumberDecimalSeparator = ",";
            if (double.TryParse(s, NumberStyles.Float, formatinfo, out d))
            {
                return d;
            }
            throw new SystemException(string.Format("strange number format '{0}'", s));
        }
