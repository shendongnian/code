    class SomeClass
    {
        private readonly ZonedClock clock;
        internal SomeClass(ZonedClock clock)
        { 
            this.clock = clock;
        }
        internal void DoSomethingWithDate()
        {
            LocalDate today = clock.GetCurrentDate();
            ...
        }
    }
