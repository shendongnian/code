    public static string Element_GetValue(AutomationElement control)
    {
        string value = null;
        object patternProvider;
        if (control.TryGetCurrentPattern(ValuePattern.Pattern, out patternProvider))
        {
            ValuePattern valuePatternProvider = patternProvider as ValuePattern;
            value = valuePatternProvider.Current.Value;
        }
        return value;
    }
    public static bool Element_SetValue(AutomationElement control, string value)
    {
        object patternProvider;
        if (control.TryGetCurrentPattern(ValuePattern.Pattern, out patternProvider))
        {
            ValuePattern valuePatternProvider = patternProvider as ValuePattern;
            valuePatternProvider.SetValue(value);
            return true;
        }
        return false;
    }
