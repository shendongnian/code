        public float Convert(string height)
        {
            if (string.IsNullOrEmpty(height))
                return 0;
            // input format: "3 ft 5 in"
            var spaceSplitted = height.Split(' ');
            if (spaceSplitted.Length <= 3)
                return 0;
            
            var concatenatedValue = spaceSplitted[0] + "." + spaceSplitted[2];
            float floatResult;
            float.TryParse(concatenatedValue, NumberStyles.Float, CultureInfo.InvariantCulture, out floatResult);
            return floatResult;
        }
