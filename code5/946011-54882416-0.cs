    public static class AutomationExtensions
    {
        public static string GetText(this AutomationElement element)
        => element.TryGetCurrentPattern(ValuePattern.Pattern, out object patternValue) ? ((ValuePattern)patternValue).Current.Value
            : element.TryGetCurrentPattern(TextPattern.Pattern, out object patternText) ? ((TextPattern)patternText).DocumentRange.GetText(-1).TrimEnd('\r') // often there is an extra '\r' hanging off the end.
            : element.Current.Name;
    }
