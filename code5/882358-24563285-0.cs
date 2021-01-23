    return System.Text.RegularExpressions.Regex.IsMatch(
        strEmailAddress,
        @"^(?=.{0,150}$)\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
        System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.RegexOptions.ECMAScript
    );
