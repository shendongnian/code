    if (bResult = Regex.IsMatch(sResult, sPattern, RegexOptions.CultureInvariant))
    {
        // Reuse bResult and preset to false.  Only passing all tests sets to true:
        bResult = false;
        // True - no reserved words or illegal characters, so test further.
        // Check wild card placement. '?' may appear anywhere, but '*' follows specific rules.
        // Use LINQ to count occurences of asterisk.  Zero to two is acceptable:
        iCount = sResult.Count(f => f == '*');
        if (iCount == 0)
        {
            // No asterisks, so search pattern testing is finished and the pattern is good.
            bResult = true;
        }
        else if (iCount == 1)
        {
            // One asterisk, so test further.  If one asterisk, it must be last character in string:
            if (sResult.Length == sResult.IndexOf("*")+1)
            {
                // One asterisk and it IS the last character.
                bResult = true;
            }
        }
        else if (iCount == 2)
        {
            // Two asterisks, so test further.  The first asterisk can ONLY be followed
            // by period.  The second asterisk must be the last character in the string:
            iIdx = sResult.IndexOf("*");
            if (sResult.Substring(iIdx+1,1) == ".")
            {
                // First asterisk is followed by period, so test further:
                if (sResult.Length == sResult.LastIndexOf("*")+1)
                {
                    // Second asterisk is the last character, so good search pattern.
                    bResult = true;
                }
            }
        }
    }
