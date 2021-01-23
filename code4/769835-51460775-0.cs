    using System;
    using System.Windows.Media;
    using SDColor = System.Drawing.Color;
     
    //Developed by امین امیری دربان
    namespace APREndUser.CodeAssist
    {
        public static class ColorHelper
        {
          public static SDColor ToSDColor(SWMColor color) => SDColor.FromArgb(color.A, color.R, color.G, color.B);
          public static Tuple<SDColor, SDColor> GetColorFromRYGGradient(double percentage)
            {
                var red = (percentage > 50 ? 1 - 2 * (percentage - 50) / 100.0 : 1.0) * 255;
                var green = (percentage > 50 ? 1.0 : 2 * percentage / 100.0) * 255;
                var blue = 0.0;
                SDColor result1 = SDColor.FromArgb((int)red, (int)green, (int)blue);
                SDColor result2 = SDColor.FromArgb((int)green, (int)red, (int)blue);
                return new Tuple<SDColor, SDColor>(result1, result2);
            }
        }
}
