    public class FollowUpEvent<T> where T: CalendarEvent
    {
        public Type EventType { get 
                                {
                                  return this.GetType().GetGenericArguments()[0]
                                  // OR
                                  // return typeof(T)
                                }
                              }
        public int OffsetDays { get; set; };
        public bool IsRequired { get; set; };
    }
