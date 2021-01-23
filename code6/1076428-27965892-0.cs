    // tsPos = 07:00:00
    string pos = "0700";
    TimeSpan tsPos = TimeSpan.ParseExact(pos, new string [] { "hhmm", @"\-hhmm" }, null,
        pos[0] == '-' ? TimeSpanStyles.AssumeNegative : TimeSpanStyles.None);
    // tsNeg = -07:00:00    		
    string neg = "-0700";
    TimeSpan tsNeg = TimeSpan.ParseExact(neg, new string [] { "hhmm", @"\-hhmm" }, null,
        neg[0] == '-' ? TimeSpanStyles.AssumeNegative : TimeSpanStyles.None);
