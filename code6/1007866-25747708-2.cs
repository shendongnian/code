    public interface ICreateDate {
    
       public DateTime CreateDate { get; set; }
    
    }
    
     public T testfunction<T, U>(U numb) where U : ICreateDate
        {
            switch(numb.CreateDate.DayOfWeek){
                case DayOfWeek.Monday:
    
            }
            ....
        }
