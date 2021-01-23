    public class HobbieSelector {
        private int mask;
        [Flags]
        private enum Masks {
            Football = 1
        ,   Tennis = 2
        ,   Hockey = 4
        ,   Basketball = 8
        ,   Baseball = 16
        }
        // This table encodes the smarts of the algorithm:
        // masks with more than one bit set are "mapped" to null,
        // while the five single-bit masks contain proper descriptions:
        private static string[] SelectionNames = new[] {
            null, "Football", "Tennis", null, "Hockey", null, null, null,
            "Basketball", null, null, null, null, null, null, null, "Baseball"
        };
        // Now the entire code boils down to indexing into an array
        public String GetSingleSelectionHobbie() {
            return SelectionNames[mask];
        }
        // The rest is an implementation of "packed" representation:
        public bool Football {
            get { return mask & Masks.Football != 0; }
            set { mask = value ? (mask | Masks.Football) : (mask & ~Masks.Football); }
        }
        public bool Tennis {
            get { return mask & Masks.Tennis != 0; }
            set { mask = value ? (mask | Masks.Tennis) : (mask & ~Masks.Tennis); }
        }
        public bool Hockey {
            get { return mask & Masks.Hockey != 0; }
            set { mask = value ? (mask | Masks.Hockey) : (mask & ~Masks.Hockey); }
        }
        public bool Basketball {
            get { return mask & Masks.Basketball != 0; }
            set { mask = value ? (mask | Masks.Basketball) : (mask & ~Masks.Basketball); }
        }
        public bool Baseball {
            get { return mask & Masks.Football != 0; }
            set { mask = value ? (mask | Masks.Football) : (mask & ~Masks.Football); }
        }
    }
