    struct Position {
        public override ToString(object o, CultureInfo culture) {
            /* Your serialization */
        }
        public override ToString() { // Will be used by OrmLite to serialize
            position.ToString(null, CultureInfo.InvariantCulture);
        }
    }
