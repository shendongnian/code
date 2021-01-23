        private static bool TryParseInteger(string controlValue, out int controlInt)
        {
            String[] groupSeparators = { ",", ".", " "};
            CultureInfo customCulture = CultureInfo.InvariantCulture.Clone() as CultureInfo;
            customCulture.NumberFormat.NumberDecimalSeparator = "SomeUnlikelyString";
    
            NumberStyles styles = NumberStyles.Integer | NumberStyles.AllowThousands;
    
            bool success = false;
            controlInt = 0;
            foreach (var separator in groupSeparators)
            {
                customCulture.NumberFormat.NumberGroupSeparator = separator;
                success = Int32.TryParse(controlValue, styles, customCulture, out controlInt);
    
                if (success)
                {
                    break;
                }
            }
                
            return success;
        }
