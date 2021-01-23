    using System;
    namespace TestLogic
    {
        internal class FuzzyLogic
        {
            public FuzzyLogic(Double init)
            {
                this.value = init;
            }
            public Double value { get; private set; }
            public static implicit operator Boolean(FuzzyLogic logic)
            {
                return logic.value < 0.1;
            }
        }
    }
