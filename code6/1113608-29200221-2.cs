    static bool ParseField(string fieldName, string fieldValueText, out double fieldValue)
    {
        if (string.IsNullOrEmpty(fieldValueText)) 
        {
            MessageBox.Show(string.Format("Please provide an input value for '{0}'.", fieldName));
            return false;
        }
        else if (!double.TryParse(fieldValueText, out fieldValue))  
        {
            MessageBox.Show(string.Format("'{0}' is not a valid floating point value. Please provide a valid floating point input value for '{1}'.", fieldValueText, fieldName));
            return false;
        }
        return true;
    }
