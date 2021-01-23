        private static void TryToParse(string value)
        {
            double number;
            bool result = double.TryParse(value, out number);
            if (result)
            {
                FabricWeight = number;
            }
            else
            {
                if (value == null) value = "";
            }
        }
