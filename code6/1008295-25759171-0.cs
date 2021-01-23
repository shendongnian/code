        /// <summary>
        /// Calculate a bezier height Y of a parameter in the range [start..end]
        /// </summary>
        public static double CalculateBezierHeightInInterval(double start, double end, double param, double y1, double y2, double y3, double y4)
        {
            return CalculateBezierHeight((param - start) / (end - start), y1, y2, y3, y4);
        }
        /// <summary>
        /// Calculate a bezier height Y of a parameter in the range [0..1]
        /// </summary>
        public static double CalculateBezierHeight(double t, double y1, double y2, double y3, double y4)
        {
            double tPower3 = t * t * t;
            double tPower2 = t * t;
            double oneMinusT = 1 - t;
            double oneMinusTPower3 = oneMinusT * oneMinusT * oneMinusT;
            double oneMinusTPower2 = oneMinusT * oneMinusT;
            double Y = oneMinusTPower3 * y1 + (3 * oneMinusTPower2 * t * y2) + (3 * oneMinusT * tPower2 * y3) + tPower3 * y4;
            return Y;
        }
