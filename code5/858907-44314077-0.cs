    public class MyObject
    {
        public string dtStr { get; set; }
        public DateTime? dt
        {
            get
            {
                DateTime? d = null;
    
                if (!string.IsNullOrWhiteSpace(dtStr) && DateTime.TryParseExact(dtStr, "dd/mm/yyyy", CultureInfo.InvariantCultureDateTimeStyles.None, out d)
                {
                    return d;
                }
    
                return d;
            }
        }
    }
