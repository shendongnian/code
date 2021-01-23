    static class Iso8601Formats
    {
        /// <summary>
        /// Represents ISO 8601 extended time format.
        /// </summary>
        public static readonly string[] TimeExtended;
        /// <summary>
        /// Represents ISO 8601 basic time format.
        /// </summary>
        public static readonly string[] TimeBasic;
        /// <summary>
        /// Represents ISO 8601 both basic and extended time format.
        /// </summary>
        public static readonly string[] Time;
        /// <summary>
        /// Represents ISO 8601 extended date format.
        /// </summary>
        public static readonly string[] DateExtended;
        /// <summary>
        /// Represents ISO 8601 basic date format.
        /// </summary>
        public static readonly string[] DateBasic;
        /// <summary>
        /// Represents ISO 8601 both basic and extended time format.
        /// </summary>
        public static readonly string[] Date;
        /// <summary>
        /// Represents ISO 8601 extended date and time format.
        /// </summary>
        public static readonly string[] DateAndTimeExtended;
        /// <summary>
        /// Represents ISO 8601 basic date and time format.
        /// </summary>
        public static readonly string[] DateAndTimeBasic;
        /// <summary>
        /// Represents ISO 8601 both basic and extended date and time format.
        /// </summary>        
        public static readonly string[] DateAndTime;
        /// <summary>
        /// Represents ISO 8601 extended date and/or time format.
        /// </summary>
        public static readonly string[] DateAndOrTimeExtended;
        /// <summary>
        /// Represents ISO 8601 basic date and/or time format.
        /// </summary>
        public static readonly string[] DateAndOrTimeBasic;
        /// <summary>
        /// Represents ISO 8601 both basic and extended date and/or time format.
        /// </summary>
        public static readonly string[] DateAndOrTime;
        static Iso8601Formats()
        {
            // date format extended
            IList<string> dateExtended = new List<string>{
                                          "yyyy'-'MM'-'dd"  // 1985-04-12
                                      };
            DateExtended = dateExtended.ToArray();
            // date format basic
            IList<string> dateBasic = new List<string>{
                                          "yyyyMMdd"        // 19850412
                                          ,"yyyy'-'MM"      // 1985-04
                                          ,"yyyy"           // 1985
                                          ,"'--'MMdd"       // --0412
                                          ,"'---'dd"        // ---12
                                      };
            DateBasic = dateBasic.ToArray();
            // date both basic and extended format
            List<string> date = new List<string>();
            date.AddRange(dateBasic);
            date.AddRange(dateExtended);
            Date = date.ToArray();
            // time format extended
            IList<string> timeExtended = new List<string>{                                          
                                          "HH':'mm':'sszzz"       // 10:22:00-0800
                                          ,"HH':'mm':'sszz"       // 10:22:00-08
                                          ,"HH':'mm':'ssZ"        // 10:22:00Z
                                          ,"HH':'mm':'ss"         // 10:22:05
                                          ,"HH':'mm"              // 10:22
                                          ,"HH"                   // 10
                                          ,"'-:'mm':'ss"          // -22:07
                                          ,"'-:-:'ss"             // -:-:07
            };
            TimeExtended = timeExtended.ToArray();
            // time format basic
            IList<string> timeBasic = new List<string>{                                          
                                          "HHmmsszzz"       // 102200-0800
                                          ,"HHmmsszz"       // 102200-08
                                          ,"HHmmssZ"        // 102200Z
                                          ,"HHmmss"         // 102205
                                          ,"HHmm"           // 1022
                                          ,"HH"             // 10
                                          ,"'-'mmss"        // -2207
                                          ,"'--'ss"         // --07
                                      };
            TimeBasic = timeBasic.ToArray();
            // time format both basic and extended
            List<string> time = new List<string>();
            time.AddRange(timeBasic);
            time.AddRange(timeExtended);
            Time = time.ToArray();
            // date-time basic
            IList<string> dateTimeBasic = 
                CombineFormats(dateBasic, timeBasic);
            DateAndTimeBasic = dateTimeBasic.ToArray();
            // date-time extended
            IList<string> dateTimeExtended = 
                CombineFormats(dateExtended, timeExtended);
            DateAndTimeExtended = dateTimeExtended.ToArray();
            // date-time both basic and extended
            List<string> dateTime = new List<string>();
            dateTime.AddRange(dateTimeBasic);
            dateTime.AddRange(dateTimeExtended);
            DateAndTime = dateTime.ToArray();
            // date-and-or-time basic format
            List<string> dateAndOrTimeBasic = new List<string>();
            dateAndOrTimeBasic.AddRange(dateTimeBasic);
            dateAndOrTimeBasic.AddRange(dateBasic);
            foreach (string timeFormat in timeBasic)
            {
                dateAndOrTimeBasic.Add("'T'" + timeFormat);
            }
            DateAndOrTimeBasic = dateAndOrTimeBasic.ToArray();
            // date-and-or-time extended format
            List<string> dateAndOrTimeExtended = new List<string>();
            dateAndOrTimeExtended.AddRange(dateTimeExtended);
            dateAndOrTimeExtended.AddRange(dateExtended);
            foreach (string timeFormat in timeExtended)
            {
                dateAndOrTimeExtended.Add("'T'" + timeFormat);
            }
            DateAndOrTimeExtended = dateAndOrTimeExtended.ToArray();
            
            // date-and-or-time basic and extended format
            List<string> dateAndOrTime = new List<string>();
            dateAndOrTime.AddRange(dateAndOrTimeBasic);
            dateAndOrTime.AddRange(dateAndOrTimeExtended);
            DateAndOrTime = dateAndOrTime.ToArray();
        }
        /// <summary>
        /// Produces all combinations of date and time formats
        /// </summary>
        /// <param name="dates">List of dates formats</param>
        /// <param name="times">List of time formats</param>
        private static IList<string> CombineFormats(IList<string> dates, IList<string> times)
        {
            List<string> dt = new List<string>();
            foreach (string dateFormat in dates)
            {
                foreach (string timeFormat in times)
                {
                    // year/month must be present if time zone is specified
                    if (dateFormat.StartsWith("'-") && (timeFormat.IndexOfAny(new[] { 'z', 'Z' }) != -1))
                        continue;
                    dt.Add(dateFormat + "'T'" + timeFormat);
                }
            }
            return dt;
        }
    }
