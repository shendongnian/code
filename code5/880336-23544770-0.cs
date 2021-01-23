        /// <summary>
        /// <para>Fades the specified color by the fading factor from interval [-1, 1].</para>
        /// <para>
        /// For example, -0.3 will make color 30% darker and 0.3 will make color 30% lighter.
        /// </para>
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="fading">The fading factor.</param>
        /// <returns>The faded color.</returns>
        private static Color Fade(Color color, double fading)
        {
            Debug.Assert(fading >= -1 && fading <= 1);
            if (fading < 0)
            {
                var shade = 1 + fading;
                return Color.FromArgb(ShadeComponent(color.R, shade), ShadeComponent(color.G, shade), ShadeComponent(color.B, shade));
            }
            else if (fading > 0)
            {
                var tint = 1 - fading;
                return Color.FromArgb(TintComponent(color.R, tint), TintComponent(color.G, tint), TintComponent(color.B, tint));
            }
            else
                return color;
        }
        private static int ShadeComponent(int component, double shade)
        {
            return Round(component * shade);
        }
        private static int TintComponent(int component, double tint)
        {
            return Round(255 - (255 - component) * tint);
        }
        private static int Round(double value)
        {
            return (int)Math.Round(value);
        }
