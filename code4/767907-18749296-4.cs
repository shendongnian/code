    public class CourseInfo
    {
        // this is now a "dumb" auto-implemented property
        // (no need for a backing field anymore)
        public string FormalDate { get; set; }
        
        // this read-only property returns the converted value
        public string LocalizedFormalDate
        {
            get 
            {
                return convertFormalDateToSpanish(FormalDate);
            }
        }
    }
