        static void Main()
        {
            Color[] ColorArray =
            {
                Color.FromArgb(255, 245, 244, 242), 
                Color.FromArgb(255, 245, 244, 240),
                Color.FromArgb(255, 245, 244, 238)
            };
            var closest = GetClosestColor(ColorArray, Color.FromArgb(255, 245, 244, 241));
            Console.WriteLine(closest);
        }
        private static Color GetClosestColor(Color[] colorArray, Color baseColor)
        {
            var colors = colorArray.Select(x => new {Value = x, Diff = GetDiff(x, baseColor)}).ToList();
            var min = colors.Min(x => x.Diff);
            return colors.Find(x => x.Diff == min).Value;
        }
        private static int GetDiff(Color color, Color baseColor)
        {
            int a = color.A - baseColor.A,
                r = color.R - baseColor.R,
                g = color.G - baseColor.G,
                b = color.B - baseColor.B;
            return a*a + r*r + g*g + b*b;
        }
