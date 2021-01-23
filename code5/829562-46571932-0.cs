        private static System.Drawing.Color ToColor(this string color)
        {
            var arrColorFragments = color?.Split(',').Select(sFragment => { int.TryParse(sFragment, out int fragment); return fragment; }).ToArray();
            switch (arrColorFragments?.Length)
            {
                case 3:
                    return System.Drawing.Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2]);
                case 4:
                    return System.Drawing.Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2], arrColorFragments[3]);
                default:
                    return System.Drawing.Color.Transparent;
            }
        }
