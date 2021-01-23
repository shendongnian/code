        public static double IEEERemainder(double x, double y) {
            if (Double.IsNaN(x)) {
                return x; // IEEE 754-2008: NaN payload must be preserved
            }
            if (Double.IsNaN(y)) {
                return y; // IEEE 754-2008: NaN payload must be preserved
            }
 
            double regularMod = x % y;
            if (Double.IsNaN(regularMod)) {
                return Double.NaN;
            }
            // ...
        }
