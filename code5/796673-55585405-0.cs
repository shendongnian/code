    public static string FormatString(string value) {
        var step1 = Regex.Replace(value, @"<[^>]+>", "").Trim();
        var step2 = Regex.Replace(step1, @"&nbsp;", " ");
        var step3 = Regex.Replace(step2, @"\s{2,}", " ");
        return step3;
    }
