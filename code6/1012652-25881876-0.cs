    public abstract class BillCalculator: IBillable 
    {
        abstract decimal Bill();
    }
    public class HourlyBillCalculator: BillCalculator
    {
       public int HoursWorked { get; set; }
       public decimal PricePerHour { get; set; }
    
       public HourlyBillCalculator(int hoursWorked, decimal pricePerHour) 
       {
          HoursWorked = hoursWorked;
          PricePerHour = pricePerHour;
       }
       
       public override Bill() 
       {
          // Calculate the Bill
       }
    }
    public class CommisionBillCalculator: BillCalculator {
         public decimal CommisionRate { get; set; }
         
         public CommisionBillCalculator(decimal rate)
         {
             CommisionRate = rate;
         }
         
         public override Bill() {
              // Calculate the Bill
         }
    }
