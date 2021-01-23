    public class DealModule
    {
        private static DealModule instance = null;
        public static DealModule Instance
        {
            get
            {
                if (instance == null)
                    instance = new DealModule();
                return instance;
            }
        }
        // other code
        public void SelectDeal(Key dealKey) ( /* ... */ }
    }
