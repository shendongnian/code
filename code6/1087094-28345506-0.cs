    namespace WebApplication1.Class
    {
        public class DailySalaryCalculator
        {
            public virtual void Calculate()
            {
            }
        }
    
        public class WeeklySalaryCalculator : DailySalaryCalculator
        {
            public override void Calculate()
            {
            }
        }
    
        public class MonthlySalaryCalculator : WeeklySalaryCalculator
        {
            public override void Calculate()
            {
                //I want to execute Calculate() of Daily Salary Calculator here.
                //Yes do this :
                
                base.Calculate();
                
                //Now, Add your additional code here
            }
        }
    }
