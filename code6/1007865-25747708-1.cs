    public interface IKnowThis {
    
       public DayOfWeek WeekDayChosen { get; set; }
    
    }
    
     public T testfunction<T, U>(U numb) where U : IKnowThis
        {
            switch(numb.WeekDayChosen){
                case DayOfWeek.Monday:
    
            }
            ....
        }
