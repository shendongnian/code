        interface IFoo<T>
        {
            T GetOtherThis();
        }
        public class WellBehaved : IFoo<WellBehaved>
        {
            WellBehaved GetOtherThis() { ... }
        }
        public class BadlyBehaved : WellBehaved
        {
            // Ha! Now x.GetOtherThis().GetType() != x.GetType()
        }
