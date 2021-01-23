        private static readonly Lazy<string> TabMainDataToolTipFactory = new Lazy<string>(() => "Main Data");
        public static string TabMainDataToolTip
        {
            get
            {
                return TabMainDataToolTipFactory.Value;
            }
        }
