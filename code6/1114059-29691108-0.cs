    // define the list that you care about
    private static readonly Dictionary<string, TimeSpan> Abbreviations = new Dictionary<string, TimeSpan>
    {
        {"EDT", TimeSpan.FromHours(-4)},
        {"EST", TimeSpan.FromHours(-5)},
        {"CDT", TimeSpan.FromHours(-5)},
        {"CST", TimeSpan.FromHours(-6)},
        {"MDT", TimeSpan.FromHours(-6)},
        {"MST", TimeSpan.FromHours(-7)},
        {"PDT", TimeSpan.FromHours(-7)},
        {"PST", TimeSpan.FromHours(-8)},
        {"AKDT", TimeSpan.FromHours(-8)},
        {"AKST", TimeSpan.FromHours(-9)},
        {"HST", TimeSpan.FromHours(-10)}
    };
    static DateTimeOffset ParseInput(string input)
    {
        // get just the datetime part, without the abbreviation
        string dateTimePart = input.Substring(0, input.LastIndexOf(" ", StringComparison.Ordinal));
        // parse it to a datetime
        DateTime dt;
        bool success = DateTime.TryParseExact(dateTimePart, "MMM dd, yyyy hh:mm tt",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            
        // handle bad input
        if (!success)
        {
            throw new ArgumentException("Invalid input string.", "input");
        }
        // get the abbreviation from the input string
        string abbreviation = input.Substring(input.LastIndexOf(" ", StringComparison.Ordinal) + 1)
                                    .ToUpperInvariant();
            
        // look up the offset from the abbreviation
        TimeSpan offset;
        success = Abbreviations.TryGetValue(abbreviation, out offset);
        if (!success)
        {
            throw new ArgumentException("Unknown time zone abbreviation.", "input");
        }
        // apply the offset to the datetime, and return
        return new DateTimeOffset(dt, offset);
    }
