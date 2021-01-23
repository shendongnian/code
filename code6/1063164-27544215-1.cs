    // I am just using German Number representations for the example.
    // Use additional string Arrays to suit the abbrevated
    // and the Genetive names.
    // Replaye with whatever suits your needs.
    string[] monthNames =
        {
          "Eins",
          "Zwei",
          "Drei",
          "Vier",
          "Fünf",
          "Sechs",
          "Sieben",
          "Acht",
          "Neun",
          "Zehn",
          "Elf",
          "Zwölf",
          string.Empty
        };
    // Assign each string Array to its corresponding property.
    // I am using the same Array here just as an example for
    // what is possible and because I am ... :-)
    ci.DateTimeFormat.MonthNames = monthNames;
    ci.DateTimeFormat.MonthGenitiveNames = monthNames;
    ci.DateTimeFormat.AbbreviatedMonthNames = monthNames;
    ci.DateTimeFormat.AbbreviatedMonthGenitiveNames = monthNames;
