        private Space[,] map;
        public Space[,] Map
        {
            get { return map; } // avoid write-only properties
            set { map = value; }
        }
