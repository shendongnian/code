    public class Salary
    {
        private Earning e;
        private Deduction d;
    
        public Salary()
        {
            this.e = new Earning();
            this.d = new Deduction();
        }
        public void override Pay()
        {
            ... 
        }
    }
