    public abstract AbstractSalaryCalculator
    {
         //note that the calculation returns something, as this is basically a service
         public virtual decimal Calculate();
     }
     public class DailySalaryCalculator:AbstractSalaryCalculator
     {
        public override decimal Calculate()
        {
             //do stuff
            //return result
        }
     }
     public class WeeklySalaryCalculator:AbstractSalaryCalculator
     {
           public override decimal Calculate()
        {
             //do stuff
            //return result
        } 
     }
    public class MonthlySalaryCalculator:AbstractSalaryCalculator
     {
         //probably is better for the daily calculator to be injected via the constructor
         public override decimal Calculate(DailySalaryCalculator daily)
        {
             //use daily to do stuff
            //return result
        } 
     }
    var daily= new DailySalaryCalculator();
    var monthly=new MonthlySalaryCalculator();
    var result=monhtly.Calculate(daily);
