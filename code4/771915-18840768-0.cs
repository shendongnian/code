    public static class ColorExtensions
    {
        public static IEnumerable<System.Drawing.Color> Range(this System.Drawing.Color firstColor, System.Drawing.Color lastColor, int count)
        {
            float stepHueClockwise = GetStepping(firstColor.GetHue(), lastColor.GetHue(), count, Direction.Clockwise);
            float stepHueCounterClockwise = GetStepping(firstColor.GetHue(), lastColor.GetHue(), count, Direction.CounterClockwise);
            if (Math.Abs(stepHueClockwise) >= Math.Abs(stepHueCounterClockwise))
                return Range(firstColor, lastColor, count, Direction.Clockwise);
            else
                return Range(firstColor, lastColor, count, Direction.CounterClockwise);
        }
        public static IEnumerable<System.Drawing.Color> Range(this System.Drawing.Color firstColor, System.Drawing.Color lastColor, int count, Direction hueDirection)
        {
            var color = firstColor;
            if (count <= 0)
                yield break;
            if (count == 1)
                yield return firstColor;
            float startingHue = color.GetHue();
            float stepHue = GetStepping(firstColor.GetHue(), lastColor.GetHue(), count - 1, hueDirection);
            var stepSaturation = (lastColor.GetSaturation() - firstColor.GetSaturation()) / (count - 1);
            var stepBrightness = (lastColor.GetBrightness() - firstColor.GetBrightness()) / (count - 1);
            var stepAlpha = (lastColor.A - firstColor.A) / (count - 1.0);
            for (int i = 1; i < count; i++)
            {
                yield return color;
                var hueValue = startingHue + stepHue * i;
                if (hueValue > 360)
                    hueValue -= 360;
                if (hueValue < 0)
                    hueValue = 360 + hueValue;
                color = FromAhsb(
                            Clamp((int)(color.A + stepAlpha), 0, 255),
                                 hueValue,
                                 Clamp(color.GetSaturation() + stepSaturation, 0, 1),
                                 Clamp(color.GetBrightness() + stepBrightness, 0, 1));
            }
            yield return lastColor;
        }
        public enum Direction
        {
            Clockwise = 0,
            CounterClockwise = 1
        }
        private static float GetStepping(float start, float end, int count, Direction direction)
        {
            var hueDiff = end - start;
            switch (direction)
            {
                case Direction.CounterClockwise:
                    if (hueDiff >= 0)
                        hueDiff = (360 - hueDiff) * -1;
                    break;
                default:
                    if (hueDiff <= 0)
                        hueDiff = 360 + hueDiff;
                    break;
            }
            return hueDiff / count;
        }
        private static int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        private static float Clamp(float value, float min, float max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
  
        public static System.Drawing.Color FromAhsb(int alpha, float hue, float saturation, float brightness)
        {
            if (0 > alpha
                || 255 < alpha)
            {
                throw new ArgumentOutOfRangeException(
                    "alpha",
                    alpha,
                    "Value must be within a range of 0 - 255.");
            }
            if (0f > hue
                || 360f < hue)
            {
                throw new ArgumentOutOfRangeException(
                    "hue",
                    hue,
                    "Value must be within a range of 0 - 360.");
            }
            if (0f > saturation
                || 1f < saturation)
            {
                throw new ArgumentOutOfRangeException(
                    "saturation",
                    saturation,
                    "Value must be within a range of 0 - 1.");
            }
            if (0f > brightness
                || 1f < brightness)
            {
                throw new ArgumentOutOfRangeException(
                    "brightness",
                    brightness,
                    "Value must be within a range of 0 - 1.");
            }
            if (0 == saturation)
            {
                return System.Drawing.Color.FromArgb(
                                    alpha,
                                    Convert.ToInt32(brightness * 255),
                                    Convert.ToInt32(brightness * 255),
                                    Convert.ToInt32(brightness * 255));
            }
            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;
            if (0.5 < brightness)
            {
                fMax = brightness - (brightness * saturation) + saturation;
                fMin = brightness + (brightness * saturation) - saturation;
            }
            else
            {
                fMax = brightness + (brightness * saturation);
                fMin = brightness - (brightness * saturation);
            }
            iSextant = (int)Math.Floor(hue / 60f);
            if (300f <= hue)
            {
                hue -= 360f;
            }
            hue /= 60f;
            hue -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = (hue * (fMax - fMin)) + fMin;
            }
            else
            {
                fMid = fMin - (hue * (fMax - fMin));
            }
            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);
            switch (iSextant)
            {
                case 1:
                    return System.Drawing.Color.FromArgb(alpha, iMid, iMax, iMin);
                case 2:
                    return System.Drawing.Color.FromArgb(alpha, iMin, iMax, iMid);
                case 3:
                    return System.Drawing.Color.FromArgb(alpha, iMin, iMid, iMax);
                case 4:
                    return System.Drawing.Color.FromArgb(alpha, iMid, iMin, iMax);
                case 5:
                    return System.Drawing.Color.FromArgb(alpha, iMax, iMin, iMid);
                default:
                    return System.Drawing.Color.FromArgb(alpha, iMax, iMid, iMin);
            }
        }
    }
