    public class DailySalaryCalculator
    {
        public void Calculate()
        {
            
        }
    }
    public class WeeklySalaryCalculator : DailySalaryCalculator
    {
        public void Calculate()
        {
            
        }
    }
    public class MonthlySalaryCalculator : WeeklySalaryCalculator
    {
        public void Calculate()
        {
            (this.MemberwiseClone() as DailySalaryCalculator).Calculate();
        }
    }
 
