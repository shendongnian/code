    private bool IsValidValue(string text)
            {
                bool isValid;
                if (text.EndsWith("."))
                {
                    text += "0";
                }
                if (Regex.IsMatch(text, @"^(\+|\-?)(((\d+)(.?)(\d+))|(\d+))$"))
                {
                    isValid = true;
                }
                return isValid;
    
            }
