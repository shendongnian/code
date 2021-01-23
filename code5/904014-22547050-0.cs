    public interface ICalculator
    {
        int Add(int a, int b);
    }
---
    namespace ClassLibraryB
    {
        public class Calculator : ICalculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
        }
    }
