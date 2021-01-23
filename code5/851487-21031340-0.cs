        /// <summary>
        /// Wraps angle between -π and π
        /// </summary>
        /// <param name="angle">The angle</param>
        /// <returns>A bounded angle value</returns>
        public static double WrapBetweenPI(this double angle)
        {
            return angle+(2*Math.PI)*Math.Floor((Math.PI-angle)/(2*Math.PI));
        }
        /// <summary>
        /// Wraps angle between -180 and 180
        /// </summary>
        /// <param name="angle">The angle</param>
        /// <returns>A bounded angle value</returns>
        public static double WrapBetween180(this double angle)
        {
            return angle+360*Math.Floor((180-angle)/360);
        }
