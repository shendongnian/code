        public static DateTime ParseExactLocalized(string dateString)
        {
            try
            {
                var mask = DateMaskServer;
                var formatsCulture = Thread.CurrentThread.CurrentCulture;
                DateTime dt;
                if (DateTime.TryParseExact(dateString, mask, formatsCulture, DateTimeStyles.None, out dt))
                    return dt;
                return DateTime.ParseExact(dateString, mask, CultureInfo.InvariantCulture);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Wrong date format.", new FormatException(string.Format("Could not parse DateTime. Value: {0}", dateString), ex));
                //throw new FormatException(string.Format("Could not parse DateTime. Value: {0}, Mask: {1}", dateString, mask), ex);                
            }
        }
