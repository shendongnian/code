    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {   
                var myDateTime = new DateTime(2013, 10, 29);
                var myEndDateTime = new DateTime(2014, 10, 29);
                var result = SplitDateRange(myDateTime, myEndDateTime, 10);
    
            }
            public static IEnumerable<SplitDateTime> SplitDateRange(DateTime start, DateTime end, int dayChunkSize)
            {
                DateTime chunkEnd;
                while ((chunkEnd = start.AddDays(dayChunkSize)) < end)
                {
                    yield return new SplitDateTime(start, chunkEnd);
                    start = chunkEnd;
                }
                yield return new SplitDateTime(start, end);
            }
        }
        public class SplitDateTime
        {
            public SplitDateTime(DateTime startDateTime, DateTime endDateTime)
            {
                StartDateTime = startDateTime;
                EndDateTime = endDateTime;
            }
            DateTime StartDateTime { get; set; }
            DateTime EndDateTime { get; set; }
        }
    }
