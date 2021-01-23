    public class LooperHelper
    {
        private int Iterations { get; set; } = 0;
        public void AddTick() {
            Iterations++;
        }
        public int GetTicks()
        {
            return Iterations;
        }
        public bool DivisibleBy(int divisor)
        {
            return (Iterations % divisor == 0);
         }
        public string ConditionalOutput(string stringoutput, int divisor, bool reverse = false)
        {
            return ((Iterations % divisor == 0) == !reverse ? stringoutput : "");
        }
    }
