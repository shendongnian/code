        /// <summary>
        /// Calculates the hue value by applying a logarithmic function to the values
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        private byte GetHueValue(ushort f)
        {
            f = Convert.ToUInt16(f < 1 ? 0 : f);
            var hue = (double)MAX_HUE_VALUE / Math.Log((double)UInt16.MaxValue, ScalaLogBase) * Math.Log(f, ScalaLogBase);
            hue = hue == Double.NegativeInfinity ? 0 : hue;
            return Convert.ToByte(hue);
        }
